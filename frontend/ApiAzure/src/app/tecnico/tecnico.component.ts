// tecnico.component.ts

import { Component, OnInit } from '@angular/core';
import { Tecnico } from './tecnico.model';
import { TecnicoService } from './tecnico.service';

@Component({
  selector: 'app-tecnico',
  templateUrl: './tecnico.component.html'
})
export class TecnicoComponent implements OnInit {
  tecnicos: Tecnico[] = [];
  tecnicoSeleccionado: Tecnico = { id: 0, nombreTecnico: '', fechaAlta: '', fechaBaja: '', empresaId: 0, categoriaId: 0 };
  modoEdicion: boolean = false;

  constructor(private tecnicoService: TecnicoService) {}

  ngOnInit(): void {
    this.getTecnicos();
  }

  getTecnicos(): void {
    this.tecnicoService.getAllTecnicos().subscribe(tecnicos => {
      this.tecnicos = tecnicos;
    });
  }

  seleccionarTecnico(tecnico: Tecnico): void {
    this.tecnicoSeleccionado = tecnico;
    this.modoEdicion = true;
  }

  cancelarEdicion(): void {
    this.tecnicoSeleccionado = { id: 0, nombreTecnico: '', fechaAlta: '', fechaBaja: '', empresaId: 0, categoriaId: 0 };
    this.modoEdicion = false;
  }

  guardarTecnico(): void {
    if (this.tecnicoSeleccionado.id === 0) {
      this.tecnicoService.createTecnico(this.tecnicoSeleccionado).subscribe(() => {
        this.getTecnicos(); 
        this.cancelarEdicion();
      });
    } else {
      this.tecnicoService.updateTecnico(this.tecnicoSeleccionado).subscribe(() => {
        this.getTecnicos();
        this.cancelarEdicion();
      });
    }
  }

  eliminarTecnico(id: number): void {
    this.tecnicoService.deleteTecnico(id).subscribe(() => {
      this.getTecnicos(); 
    });
  }
}
