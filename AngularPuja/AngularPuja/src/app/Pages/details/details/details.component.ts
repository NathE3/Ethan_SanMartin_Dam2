import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';  // Importar Router
import { Ferrari } from '../../../Models/ferrari';
import { FerrarisService } from '../../../ferrari-service.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  router: Router = inject(Router); 
  ferrari: Ferrari | undefined;

  ferrarrisService: FerrarisService = inject(FerrarisService);

  constructor() {
    const ferrariId = parseInt(this.route.snapshot.params['id'], 10);

    this.ferrarrisService.getFerrariById(ferrariId).subscribe(
      (ferrari: Ferrari) => {
        this.ferrari = ferrari;
      },
      (error) => {
        console.error('Error al obtener el producto:', error);
      }
    );
  }

  navigateToBidPage() {
    if (this.ferrari?.id) {
      this.router.navigate([`/bid/${this.ferrari.id}`]); 
    }
  }
  
}
