import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Ferrari } from '../Models/ferrari';

@Component({
  selector: 'app-ferrari',
  imports: [RouterModule, CommonModule],
  templateUrl: './ferrari.component.html',
  styleUrls: ['./ferrari.component.css']
})
export class FerrariComponent {
 
  @Input() ferrari!: Ferrari; 
}
