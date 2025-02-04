import { Component, inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouterModule } from '@angular/router';
import { FerrariLocations } from 'src/app/models/ferrarilocations';
import { FerrarisService } from 'src/app/services/ferraris.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-details',
  standalone: true, 
  imports: [ReactiveFormsModule, RouterModule, CommonModule], 
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent implements OnInit {
  route: ActivatedRoute = inject(ActivatedRoute);
  ferrariService: FerrarisService = inject(FerrarisService); 

  @Input() ferrari!: FerrariLocations; // Ferrari seleccionado

 
  applyForm = new FormGroup({
    name: new FormControl(''), // Nombre del postor
    puja: new FormControl(0), // Cantidad de la puja
  });

  ngOnInit(): void {
    // Obtén el ID del Ferrari desde la ruta
    const ferrariId = Number(this.route.snapshot.params['id']);

    // Carga los detalles del Ferrari
    this.ferrariService.getEntity(ferrariId).subscribe({
      next: (ferrari) => {
        this.ferrari = ferrari;
      },
      error: (err) => {
        console.error('Error loading Ferrari details:', err);
      },
    });
  }

  // Envía la puja
  submitApplication(): void {
    const name = this.applyForm.value.name ?? '';
    const puja = Number(this.applyForm.value.puja) ?? 0;

    if (name && puja > 0) {
      this.ferrariService.submitApplication(name, puja, this.ferrari.id, this.ferrari);
      
    } else {
      alert('Please fill out all fields correctly.');
    }
  }
}