// tecnico.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tecnico } from './tecnico.model';

@Injectable({
  providedIn: 'root'
})
export class TecnicoService {
  private apiUrl = 'https://seminariosenati24.azurewebsites.net/api/Tecnico';

  constructor(private http: HttpClient) {}

  getAllTecnicos(): Observable<Tecnico[]> {
    return this.http.get<Tecnico[]>(`${this.apiUrl}/Get`);
  }

  getTecnicoById(id: number): Observable<Tecnico> {
    return this.http.get<Tecnico>(`${this.apiUrl}/Get/${id}`);
  }

  createTecnico(tecnico: Tecnico): Observable<Tecnico> {
    return this.http.post<Tecnico>(`${this.apiUrl}/AgregarTecnico`, tecnico);
  }

  updateTecnico(tecnico: Tecnico): Observable<Tecnico> {
    return this.http.post<Tecnico>(`${this.apiUrl}/UpdateTecnico`, tecnico);
  }

  deleteTecnico(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteTecnico/${id}`);
  }
}
