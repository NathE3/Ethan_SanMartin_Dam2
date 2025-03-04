import { Component, Input } from '@angular/core';
import { objetoModel } from '../../models/objetoModel';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-objeto',
  imports: [RouterModule, CommonModule],
  standalone: true,
  templateUrl: './objeto.component.html',
  styleUrls: ['./objeto.component.css']
})
export class ObjetoComponent {
  @Input() objeto!: objetoModel;
}
