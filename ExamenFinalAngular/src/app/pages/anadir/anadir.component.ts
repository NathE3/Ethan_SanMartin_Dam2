import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { ObjetoService } from 'src/app/service/objeto.service';
import { CreateObjetoModel } from 'src/app/models/CreateObjetoModel';

@Component({
  selector: 'app-anadir',
  standalone: true,
  imports: [FormsModule], 
  templateUrl: './anadir.component.html',
  styleUrls: ['./anadir.component.css']
})
export class AnadirComponent { 
  nuevoObjeto: CreateObjetoModel = { name: '', boolOption: true };

  constructor(private objetoService: ObjetoService) {} 

  async crearObjeto() {
    if (this.nuevoObjeto.name.trim() === '') {
      alert('El nombre es obligatorio.');
      return;
    }

    this.nuevoObjeto.boolOption = Boolean(this.nuevoObjeto.boolOption);

    try {
      const resultado = await this.objetoService.createProduct(this.nuevoObjeto);
      if (resultado) {
        console.log('Producto creado:', resultado);
        alert('Producto creado exitosamente');
      } else {
        alert('Error al crear el producto.');
      }
    } catch (error) {
      console.error('Error al crear el producto:', error);
      alert('Error al conectar con el servidor.');
    }
  }

  goBack() {
    window.history.back();
  }
}
