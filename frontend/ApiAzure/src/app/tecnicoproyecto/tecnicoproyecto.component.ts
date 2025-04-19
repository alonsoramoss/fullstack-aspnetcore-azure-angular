// tecnicoproyecto.component.ts

import { Component, OnInit } from '@angular/core';
import { Tecnicoproyecto } from './tecnicoproyecto.model';
import { TecnicoproyectoService } from './tecnicoproyecto.service';

@Component({
  selector: 'app-tecnicoproyecto',
  templateUrl: './tecnicoproyecto.component.html'
})
export class TecnicoproyectoComponent implements OnInit {
  tecnicoproyectos: Tecnicoproyecto[] = [];
  tecnicoproyectoSeleccionado: Tecnicoproyecto = { tecnicoId: 0, proyectoId: 0, fechaAsignacion: '', fechaCese: '' };
  modoEdicion: boolean = false;

  constructor(private tecnicoproyectoService: TecnicoproyectoService) {}

  ngOnInit(): void {
    this.getTecnicoproyectos();
  }

  getTecnicoproyectos(): void {
    this.tecnicoproyectoService.getAllTecnicoproyectos().subscribe(tecnicoproyectos => {
      this.tecnicoproyectos = tecnicoproyectos;
    });
  }

  seleccionarTecnicoproyecto(tecnicoproyecto: Tecnicoproyecto): void {
    this.tecnicoproyectoSeleccionado = tecnicoproyecto;
    this.modoEdicion = true;
  }

  cancelarEdicion(): void {
    this.tecnicoproyectoSeleccionado = { tecnicoId: 0, proyectoId: 0, fechaAsignacion: '', fechaCese: '' };
    this.modoEdicion = false;
  }

  guardarTecnicoproyecto(): void {
    if (this.tecnicoproyectoSeleccionado.tecnicoId === 0 || this.tecnicoproyectoSeleccionado.proyectoId === 0) {
      console.log("Por favor, seleccione un técnico y un proyecto");
      return;
    }

    if (this.tecnicoproyectoSeleccionado.fechaCese && this.tecnicoproyectoSeleccionado.fechaAsignacion > this.tecnicoproyectoSeleccionado.fechaCese) {
      console.log("La fecha de asignación no puede ser mayor que la fecha de cese");
      return;
    }

    if (this.modoEdicion) {

      this.tecnicoproyectoService.updateTecnicoproyecto(this.tecnicoproyectoSeleccionado).subscribe(() => {
        this.getTecnicoproyectos(); 
        this.cancelarEdicion();
      });
    } else {
      this.tecnicoproyectoService.createTecnicoproyecto(this.tecnicoproyectoSeleccionado).subscribe(() => {
        this.getTecnicoproyectos(); 
        this.cancelarEdicion();
      });
    }
  }

  eliminarTecnicoproyecto(tecnicoId: number, proyectoId: number): void {
    this.tecnicoproyectoService.deleteTecnicoproyecto(tecnicoId, proyectoId).subscribe(() => {
      this.getTecnicoproyectos(); 
    });
  }
}
