import { Component, Input } from '@angular/core';
import { FerrariLocations } from '../../models/ferrarilocations';

@Component({
  selector: 'app-ferrrari-component',
  imports: [],
  templateUrl: './ferrrari-component.component.html',
  styleUrls: ['./ferrrari-component.component.css']
})
export class FerrarilocationsComponent {
  
  @Input() ferrrari-component!; FerrariLocations;
  
}
