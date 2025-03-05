import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ObjetoComponent } from 'src/app/component/objeto/objeto.component';
import { objetoModel } from 'src/app/models/objetoModel';
import { ObjetoService } from 'src/app/service/objeto.service';

@Component({
  selector: 'app-principal',
  imports: [CommonModule, ObjetoComponent, RouterLink],
  standalone: true,
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})

export class PrincipalComponent{

  objetoList: objetoModel[] = [];

  constructor(private objetoService: ObjetoService){ 
    this.objetoService.getAllProduct().then((objetoList: objetoModel[]) => {
      this.objetoList = objetoList;
  });
}
}