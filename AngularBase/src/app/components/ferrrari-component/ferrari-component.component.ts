import { Component, Input } from '@angular/core';
import { FerrariLocations } from '../../models/ferrarilocations';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ferrari-component',
  imports: [RouterModule, CommonModule],
  templateUrl: './ferrari-component.component.html',
  styleUrls: ['./ferrari-component.component.css']
})
export class FerrariLocationsComponent {
 
  @Input() ferrarilocations!: FerrariLocations; 
}
