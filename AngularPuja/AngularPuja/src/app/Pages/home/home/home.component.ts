import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Ferrari } from '../../../Models/ferrari';
import { FerrarisService } from '../../../ferrari-service.service';
import { FerrariComponent } from '../../../ferrari/ferrari.component';

@Component({
  selector: 'app-home',
  imports: [CommonModule,FerrariComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  ferrariList: Ferrari[] = [];
  filteredList: Ferrari[] = [];
  errorMessage: string = '';

  constructor(private ferarrisService: FerrarisService) {}
  
  ngOnInit(): void {
    this. ferarrisService.login('ethan', 'G4!p@ssw0rd')
      .subscribe(
        (response: any) => {
          this.loadProducts(); 
        },
        (error) => {
          this.errorMessage = 'Error a la hora de logearse';
          console.error('Login error:', error); 
        }
      );
  }
   
  loadProducts(): void {
    this.ferarrisService.getAllFerrari()
      .subscribe(
        (data: Ferrari[]) => {
          this.ferrariList = data;
          this.filteredList = data;
        },
        (error) => {
          this.errorMessage = 'Failed to load products';
        }
      );
    }

    filterResults(text: string) {
      if (!text) {
        this.filteredList = this.filteredList;
        return;
      }
      this.filteredList = this.ferrariList.filter((ferrari) =>
        ferrari?.name.toLowerCase().includes(text.toLowerCase())
      );
    }
}
