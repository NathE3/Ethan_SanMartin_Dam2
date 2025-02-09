import { Injectable } from '@angular/core';
import { Ferrari } from './Models/ferrari';
import { Puja } from './Models/puja';


@Injectable({
providedIn: 'root'
})
export class FerrarisService {
ferrariList: Ferrari[];
readonly apiUrl = 'http://localhost:5072/api/Ferrari';
readonly pujaUrl = 'http://localhost:5072/api/Puja';


constructor(){
    this.ferrariList=[]
}

async getAllFerrari(): Promise<Ferrari[]> {
    let headers = new Headers();
    headers.append('Authorization', '');
    const data = await fetch(this.apiUrl,{method:'GET',
      headers: headers,
     });
    return (await data.json()) ?? [];
  }

async getFerrariById(id: number): Promise<Ferrari | undefined> {
    const data = await fetch(`${this.apiUrl}/${id}`);
    return (await data.json()) ?? {};
  }

  async postPuja(puja:Puja): Promise<Puja> {
    let headers = new Headers();
    headers.append('Authorization', '');
    headers.append('Content-Type', 'application/json');
    const data = await fetch(this.pujaUrl,{method:'POST',
      headers: headers,
      body: JSON.stringify(puja),
     });
    return (await data.json()) ?? [];
  }

  async getPujaActual(id: number): Promise<number> {
    let headers = new Headers();
    headers.append('Authorization', '');
    const data = await fetch(this.pujaUrl,{method:'GET',
      headers: headers,
     });
    var pujaList: Puja[] = (await data.json()) ?? [];
    
    pujaList = pujaList.filter((puja: Puja) => puja.id_ferrari === id);
    
    let pujaMaxima =  (await this.getFerrariById(id))?.pujaInicial ?? 0;

    for (let puja of pujaList) {
      pujaMaxima = pujaMaxima>= puja.puja? pujaMaxima : puja.puja;
    }
  
  return pujaMaxima;
}

  async submitApplication(id: number, name: string, puja: number): Promise<boolean> {
    
    if (await this.getPujaActual(id) < puja){
    const nuevaPuja: Puja = {
      id: 0,
      id_ferrari: id,
      name: name,
      puja: puja
    }

    var resultado = await this.postPuja(nuevaPuja);
    
    if (resultado &&  
        'id' in resultado &&
        'id_ferrari' in resultado &&
        'name' in resultado &&
        'puja' in resultado
    ){
      return true;
    }
  }
  return false;
}

}
