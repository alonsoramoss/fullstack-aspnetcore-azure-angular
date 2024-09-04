// conocimiento.component.ts

import { Component, OnInit } from '@angular/core';
import { Conocimiento } from './conocimiento.model';
import { ConocimientoService } from './conocimiento.service';

@Component({
  selector: 'app-conocimiento',
  templateUrl: './conocimiento.component.html'
})
export class ConocimientoComponent implements OnInit {
  conocimientos: Conocimiento[] = [];
  conocimientoSeleccionado: Conocimiento = { id: 0, tituloConoc: '', areaConoc: '', tecnicoId: 0 };
  modoEdicion: boolean = false;

  constructor(private conocimientoService: ConocimientoService) {}

  ngOnInit(): void {
    this.getConocimientos();
  }

  getConocimientos(): void {
    this.conocimientoService.getAllConocimientos().subscribe(conocimientos => {
      this.conocimientos = conocimientos;
    });
  }

  seleccionarConocimiento(conocimiento: Conocimiento): void {
    this.conocimientoSeleccionado = conocimiento;
    this.modoEdicion = true;
  }

  cancelarEdicion(): void {
    this.conocimientoSeleccionado = { id: 0, tituloConoc: '', areaConoc: '', tecnicoId: 0 };
    this.modoEdicion = false;
  }

  guardarConocimiento(): void {
    if (this.conocimientoSeleccionado.id === 0) {
      this.conocimientoService.createConocimiento(this.conocimientoSeleccionado).subscribe(() => {
        this.getConocimientos(); 
        this.cancelarEdicion();
      });
    } else {
      this.conocimientoService.updateConocimiento(this.conocimientoSeleccionado).subscribe(() => {
        this.getConocimientos();
        this.cancelarEdicion();
      });
    }
  }

  eliminarConocimiento(id: number): void {
    this.conocimientoService.deleteConocimiento(id).subscribe(() => {
      this.getConocimientos();
    });
  }
}
