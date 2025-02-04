import { Injectable } from '@angular/core';
import { Ferrari } from './Models/ferrari';
import { Puja } from './Models/puja';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
providedIn: 'root'
})
export class FerrarisService {
private apiUrl = 'http://localhost:5072/api/';


puja: Puja | undefined;

submitApplication(Name: string, puja: number, Id: number, ferrari: Ferrari | undefined) {
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

getEntities(): Observable<Ferrari[]> {
return this.http.get<Ferrari[]>(this.apiUrl+"Ferrari");
}

getEntity(id: number): Observable<Ferrari> {
return this.http.get<Ferrari>(`${this.apiUrl+"Ferrari"}/${id}`);
}

createEntity(entity: Ferrari): Observable<Ferrari> {
return this.http.post<Ferrari>(this.apiUrl+"Ferrari", entity);
}

createPuja(entity: Puja): Observable<Puja> {
return this.http.post<Puja>(this.apiUrl+"Puja", entity);
}

updateEntity(id: number, entity: Ferrari): Observable<Ferrari> {
return this.http.put<Ferrari>(`${this.apiUrl+"Ferrari"}/${id}`, entity);
}

deleteEntity(id: number): Observable<Ferrari> {
return this.http.delete<Ferrari>(`${this.apiUrl+"Ferrari"}/${id}`);
}
}
