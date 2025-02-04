import { Component, inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouterModule } from '@angular/router';
import { Ferrari } from '../../../Models/ferrari';
import { FerrarisService } from '../../../ferrari-service.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-details',
  standalone: true, 
  imports: [ReactiveFormsModule, RouterModule, CommonModule], 
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  ferrariService: FerrarisService = inject(FerrarisService); 

  @Input() ferrari!: Ferrari; 

 
  applyForm = new FormGroup({
    name: new FormControl(''), 
    puja: new FormControl(0), 
  });

  constructor() {

    const ferrariId = Number(this.route.snapshot.params['id']);


    this.ferrariService.getEntity(ferrariId).subscribe({
      next: (ferrari) => {
        this.ferrari = ferrari;
      },
      error: (err) => {
        console.error('Error loading Ferrari details:', err);
      },
    });
  }


  submitApplication(): void {
    const name = this.applyForm.value.name ?? '';
    const puja = Number(this.applyForm.value.puja) ?? 0;

    if (name && puja > 0) {
      this.ferrariService.submitApplication(name, puja, this.ferrari.id, this.ferrari);
      
    } else {
      alert('Operación no válida.');
    }
  }
}
