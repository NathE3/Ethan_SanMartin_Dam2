import { Component, inject } from '@angular/core';
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
export class HomeComponent {
  ferrarisService:FerrarisService = inject(FerrarisService);
  ferrariList: Ferrari[] = [];
  filteredList: Ferrari[] = [];

  constructor() 
  {
   
      this.ferrarisService.getEntities().subscribe((data: Ferrari[]) => {
      this.ferrariList = data;
      this.filteredList = data;
      });
  } 


  filterResults(text: string) {
    if (!text) {
      this.filteredList = this.ferrariList;
      return;
    }   
    this.filteredList = this.ferrariList.filter((ferrari) =>
      ferrari?.anoSalida.toLowerCase().includes(text.toLowerCase()) ||
      ferrari?.name.toLowerCase().includes(text.toLowerCase()) 
    );
  }
}
