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

  applyForm: FormGroup;

  ferrari: Ferrari | undefined;
  ferrariService: FerrarisService;

  pujaActual: Number|undefined;

  constructor(ferrariService: FerrarisService) {
    const ferrariId = parseInt(this.route.snapshot.params['id'], 10);
    ferrariService.getFerrariById(ferrariId).then((ferrari) => {
      this.ferrari = ferrari;
      if (ferrari){
        this.getPuja(ferrari.id)
      }
      
    });
    this.ferrariService=ferrariService;

    this.applyForm = new FormGroup({
      nombre: new FormControl<string>(''),
      puja: new FormControl<Number|undefined>(this.pujaActual ?? 0),
    });
  }

  async getPuja(id: number){
      this.pujaActual = await this.ferrariService.getPujaActual(id) ?? 0;
  }

  async submitApplication() {

    if(this.ferrari && await this.ferrariService.submitApplication(
      this.ferrari?.id,
      this.applyForm.value.nombre ?? '',
      this.applyForm.value.puja ?? 0,

    )){
      this.pujaActual = this.applyForm.value.puja;
      console.log('Puja realizada')
    }
    else{
      console.log('Error en la puja')
    }
  }
}
