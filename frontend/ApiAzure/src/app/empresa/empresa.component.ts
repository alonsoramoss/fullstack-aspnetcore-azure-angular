// empresa.component.ts

import { Component, OnInit } from '@angular/core';
import { Empresa } from './empresa.model';
import { EmpresaService } from './empresa.service';

@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html'
})
export class EmpresaComponent implements OnInit {
  empresas: Empresa[] = []; // Inicializando el array vacío
  empresaSeleccionada: Empresa = { id: 0, nombreEmpresa: '' };
  modoEdicion: boolean = false;

  constructor(private empresaService: EmpresaService) {}

  ngOnInit(): void {
    this.getEmpresas();
  }

  getEmpresas(): void {
    this.empresaService.getAllEmpresas().subscribe(empresas => {
      this.empresas = empresas;
    });
  }

  seleccionarEmpresa(empresa: Empresa): void {
    this.empresaSeleccionada = empresa;
    this.modoEdicion = true;
  }

  cancelarEdicion(): void {
    this.empresaSeleccionada = { id: 0, nombreEmpresa: '' };
    this.modoEdicion = false;
  }

  guardarEmpresa(): void {
    if (this.empresaSeleccionada.id === 0) {
      this.empresaService.createEmpresa(this.empresaSeleccionada).subscribe(() => {
        this.getEmpresas(); 
        this.cancelarEdicion();
      });
    } else {
      this.empresaService.updateEmpresa(this.empresaSeleccionada).subscribe(() => {
        this.getEmpresas(); 
        this.cancelarEdicion();
      });
    }
  }

  eliminarEmpresa(id: number): void {
    this.empresaService.deleteEmpresa(id).subscribe(() => {
      this.getEmpresas(); 
    });
  }
}
