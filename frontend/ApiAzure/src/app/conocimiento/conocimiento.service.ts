// conocimiento.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Conocimiento } from './conocimiento.model';

@Injectable({
  providedIn: 'root'
})
export class ConocimientoService {
  private apiUrl = 'https://seminariosenati24.azurewebsites.net/api/Conocimiento';

  constructor(private http: HttpClient) {}

  getAllConocimientos(): Observable<Conocimiento[]> {
    return this.http.get<Conocimiento[]>(`${this.apiUrl}/Get`);
  }

  getConocimientoById(id: number): Observable<Conocimiento> {
    return this.http.get<Conocimiento>(`${this.apiUrl}/Get/${id}`);
  }

  createConocimiento(conocimiento: Conocimiento): Observable<Conocimiento> {
    return this.http.post<Conocimiento>(`${this.apiUrl}/AgregarConocimiento`, conocimiento);
  }

  updateConocimiento(conocimiento: Conocimiento): Observable<Conocimiento> {
    return this.http.post<Conocimiento>(`${this.apiUrl}/UpdateConocimiento`, conocimiento);
  }

  deleteConocimiento(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteConocimiento/${id}`);
  }
}
