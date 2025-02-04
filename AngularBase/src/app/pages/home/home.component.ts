import { Component, inject } from '@angular/core';
import { FerrariLocations } from '../../models/ferrarilocations';
import { CommonModule } from '@angular/common';
import { FerrarisService } from 'src/app/services/ferraris.service';
import { FerrariLocationsComponent } from 'src/app/components/ferrrari-component/ferrari-component.component';

@Component({
  selector: 'app-home',
  imports: [CommonModule, FerrariLocationsComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  ferrarisService:FerrarisService = inject(FerrarisService);
  ferrariLocationList: FerrariLocations[] = [];
  filteredLocationList: FerrariLocations[] = [];

  constructor() 
  {
   
      this.ferrarisService.getEntities().subscribe((data) => {
      this.ferrariLocationList = data;
      this.filteredLocationList = data;
      });
  } 


  filterResults(text: string) {
    if (!text) {
      this.filteredLocationList = this.ferrariLocationList;
      return;
    }   
    this.filteredLocationList = this.ferrariLocationList.filter((ferrariLocation) =>
      ferrariLocation?.anoSalida.toLowerCase().includes(text.toLowerCase()) ||
      ferrariLocation?.name.toLowerCase().includes(text.toLowerCase()) 
    );
  }
}
