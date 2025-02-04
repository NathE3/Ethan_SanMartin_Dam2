import { Injectable } from '@angular/core';
import { FerrariLocations } from '../models/ferrarilocations';
import { Puja } from '../models/puja';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
providedIn: 'root'
})
export class FerrarisService {
private apiUrl = 'https://localhost:5072/api/';


puja: Puja | undefined;

submitApplication(Name: string, puja: number, Id: number, ferrari: FerrariLocations | undefined) {
this.puja = {
Name: Name,
id_ferrari: Id,
puja: puja
}

if (ferrari) {
this.updateEntity(Id, ferrari).subscribe({
next: (response) => {
console.log('Puja created successfully:', response);
},
error: (err) => {
console.error('Error creating puja:', err);
}
});
}

if (this.puja) {
if(ferrari) {
if(ferrari.precioEstimado < puja){
this.createPuja(this.puja).subscribe({
next: (response) => {
console.log('Puja created successfully:', response);
},
error: (err) => {
console.error('Error creating puja:', err);
}
});
}
}
}
}

constructor(private http: HttpClient) {
}

getEntities(): Observable<FerrariLocations[]> {
return this.http.get<FerrariLocations[]>(this.apiUrl+"Ferrari");
}

getEntity(id: number): Observable<FerrariLocations> {
return this.http.get<FerrariLocations>(`${this.apiUrl+"Ferrari"}/${id}`);
}

createEntity(entity: FerrariLocations): Observable<FerrariLocations> {
return this.http.post<FerrariLocations>(this.apiUrl+"Ferrari", entity);
}

createPuja(entity: Puja): Observable<Puja> {
return this.http.post<Puja>(this.apiUrl+"Puja", entity);
}

updateEntity(id: number, entity: FerrariLocations): Observable<FerrariLocations> {
return this.http.put<FerrariLocations>(`${this.apiUrl+"Ferrari"}/${id}`, entity);
}

deleteEntity(id: number): Observable<FerrariLocations> {
return this.http.delete<FerrariLocations>(`${this.apiUrl+"Ferrari"}/${id}`);
}
}
