import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router'; 
import { NgIf } from '@angular/common';  
import { FormsModule } from '@angular/forms';
import { Ferrari } from '../../Models/ferrari';
import { FerrarisService } from '../../ferrari-service.service';

@Component({
  selector: 'app-bid-page',
  standalone: true, 
  templateUrl: './bid.component.html',
  styleUrls: ['./bid.component.css'],
  imports: [NgIf, FormsModule]
})
export class BidComponent implements OnInit {
  
  ferrariId: number | undefined;
  ferrari: Ferrari | undefined;
  bidAmount: number = 0.0;
  highestBid: number = 0.0;

  private route = inject(ActivatedRoute);  
  private ferrarisService = inject(FerrarisService);  

  ngOnInit(): void {
  
    this.ferrariId = parseInt(this.route.snapshot.paramMap.get('id')!, 10);

    if (this.ferrariId) {
      
      this.ferrarisService.getFerrariById(this.ferrariId).subscribe(
        (ferrari: Ferrari) => {
          this.ferrari = ferrari;
          this.bidAmount = this.ferrari.pujaInicial;
          this.loadHighestBid();
        },
        (error) => {
          console.error('Error al obtener el producto:', error);
        }
      );
    }
  }

  loadHighestBid(): void {
    if (this.ferrariId) {
    
      this.ferrarisService.getHighestBidForFerrari(this.ferrariId).subscribe(
        (highestBid) => {
          this.highestBid = highestBid.price;
        },
        (error) => {
          console.error('Error al obtener la puja más alta:', error);
        }
      );
    }
  }

  submitBid(event: Event): void {
    event.preventDefault();
    if (!this.ferrariId || !this.ferrari || this.bidAmount <= this.ferrari.pujaInicial || this.bidAmount <= this.highestBid) {
      alert('Introduce una cantidad válida para pujar.');
      return;
    }
  
    const bidData = {
      price: this.bidAmount,
      ferrariId: this.ferrariId
    };
  
    this.ferrarisService.placeBid(bidData).subscribe(
      () => {
        alert('Puja realizada con éxito.');
        this.loadHighestBid();
      },
      (error) => {
        console.error('Error al enviar la puja:', error);
        alert('Hubo un error al realizar la puja.');
      }
    );
  }
  
}

