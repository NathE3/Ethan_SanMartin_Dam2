import { Injectable } from '@angular/core';
import { objetoModel } from '../models/objetoModel';
import { CreateObjetoModel } from '../models/CreateObjetoModel';

@Injectable({
  providedIn: 'root'
})
export class ObjetoService {
  readonly baseUrl = 'http://localhost:7000/api/Objeto';

  constructor() {}

  private getAuthHeaders(): { [key: string]: string } {
    const token = localStorage.getItem('token');
    return {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    };
  }

  async getAllProduct(): Promise<objetoModel[]> {
    const response = await fetch(this.baseUrl, {
      method: 'GET',
      headers: this.getAuthHeaders()
    });
    return (await response.json()) ?? [];
  }

  async getProductById(id: number): Promise<objetoModel | undefined> {
    const response = await fetch(`${this.baseUrl}/${id}`, {
      method: 'GET',
      headers: this.getAuthHeaders()
    });
    return (await response.json()) as objetoModel | undefined;
  }

  async updateProduct(id: number, partialProduct: Partial<objetoModel>): Promise<objetoModel> {
    const response = await fetch(`${this.baseUrl}/${id}`, {
      method: "PATCH",
      headers: this.getAuthHeaders(),
      body: JSON.stringify(partialProduct)
    });

    return await response.json();
  }

  async createProduct(product: CreateObjetoModel): Promise<CreateObjetoModel> {
    const response = await fetch(this.baseUrl, {
      method: "POST",
      headers: this.getAuthHeaders(),
      body: JSON.stringify(product)
    });

    return await response.json();
  }
  
  async deleteProduct(id: number): Promise<boolean> {
    const response = await fetch(`${this.baseUrl}/${id}`, {
      method: "DELETE",
      headers: this.getAuthHeaders()
    });
  
    return response.ok; // Devuelve `true` si la eliminación fue exitosa
  }
  
}
