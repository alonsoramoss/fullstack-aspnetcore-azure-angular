// proyecto.component.ts

import { Component, OnInit } from '@angular/core';
import { Proyecto } from './proyecto.model';
import { ProyectoService } from './proyecto.service';

@Component({
  selector: 'app-proyecto',
  templateUrl: './proyecto.component.html'
})
export class ProyectoComponent implements OnInit {
  proyectos: Proyecto[] = [];
  proyectoSeleccionado: Proyecto = { id: 0, nombreProyecto: '', fechaInicio: '', fechaFin: '', clienteId: 0 };
  modoEdicion: boolean = false;

  constructor(private proyectoService: ProyectoService) {}

  ngOnInit(): void {
    this.getProyectos();
  }

  getProyectos(): void {
    this.proyectoService.getAllProyectos().subscribe(proyectos => {
      this.proyectos = proyectos;
    });
  }

  seleccionarProyecto(proyecto: Proyecto): void {
    this.proyectoSeleccionado = proyecto;
    this.modoEdicion = true;
  }

  cancelarEdicion(): void {
    this.proyectoSeleccionado = { id: 0, nombreProyecto: '', fechaInicio: '', fechaFin: '', clienteId: 0 };
    this.modoEdicion = false;
  }

  guardarProyecto(): void {
    if (this.proyectoSeleccionado.id === 0) {
      this.proyectoService.createProyecto(this.proyectoSeleccionado).subscribe(() => {
        this.getProyectos(); 
        this.cancelarEdicion();
      });
    } else {
      this.proyectoService.updateProyecto(this.proyectoSeleccionado).subscribe(() => {
        this.getProyectos();
        this.cancelarEdicion();
      });
    }
  }

  eliminarProyecto(id: number): void {
    this.proyectoService.deleteProyecto(id).subscribe(() => {
      this.getProyectos(); 
    });
  }
}
