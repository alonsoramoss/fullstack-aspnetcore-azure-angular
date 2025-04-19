// tecnicoproyecto.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tecnicoproyecto } from './tecnicoproyecto.model';

@Injectable({
  providedIn: 'root'
})
export class TecnicoproyectoService {
  private apiUrl = 'https://seminariosenati24.azurewebsites.net/api/TecnicoProyecto';

  constructor(private http: HttpClient) {}

  getAllTecnicoproyectos(): Observable<Tecnicoproyecto[]> {
    return this.http.get<Tecnicoproyecto[]>(`${this.apiUrl}/Get`);
  }

  createTecnicoproyecto(tecnicoproyecto: Tecnicoproyecto): Observable<Tecnicoproyecto> {
    return this.http.post<Tecnicoproyecto>(`${this.apiUrl}/AgregarTecnicoProyecto`, tecnicoproyecto);
  }

  updateTecnicoproyecto(tecnicoproyecto: Tecnicoproyecto): Observable<Tecnicoproyecto> {
    return this.http.post<Tecnicoproyecto>(`${this.apiUrl}/UpdateTecnicoProyecto`, tecnicoproyecto);
  }

  deleteTecnicoproyecto(tecnicoId: number, proyectoId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteTecnicoProyecto/${tecnicoId}/${proyectoId}`);
  }
}
