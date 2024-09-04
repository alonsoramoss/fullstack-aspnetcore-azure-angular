// cliente.component.ts

import { Component, OnInit } from '@angular/core';
import { Cliente } from './cliente.model';
import { ClienteService } from './cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html'
})
export class ClienteComponent implements OnInit {
  clientes: Cliente[] = [];
  clienteSeleccionado: Cliente = { id: 0, nombreCliente: '' };
  modoEdicion: boolean = false;

  constructor(private clienteService: ClienteService) {}

  ngOnInit(): void {
    this.getClientes();
  }

  getClientes(): void {
    this.clienteService.getAllClientes().subscribe(clientes => {
      this.clientes = clientes;
    });
  }

  seleccionarCliente(cliente: Cliente): void {
    this.clienteSeleccionado = cliente;
    this.modoEdicion = true;
  }

  cancelarEdicion(): void {
    this.clienteSeleccionado = { id: 0, nombreCliente: '' };
    this.modoEdicion = false;
  }

  guardarCliente(): void {
    if (this.clienteSeleccionado.id === 0) {
      this.clienteService.createCliente(this.clienteSeleccionado).subscribe(() => {
        this.getClientes(); 
        this.cancelarEdicion();
      });
    } else {
      this.clienteService.updateCliente(this.clienteSeleccionado).subscribe(() => {
        this.getClientes(); 
        this.cancelarEdicion();
      });
    }
  }

  eliminarCliente(id: number): void {
    this.clienteService.deleteCliente(id).subscribe(() => {
      this.getClientes(); 
    });
  }
}
