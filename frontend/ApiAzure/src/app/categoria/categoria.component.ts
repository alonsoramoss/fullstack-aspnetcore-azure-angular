// categoria.component.ts

import { Component, OnInit } from '@angular/core';
import { Categoria } from './categoria.model';
import { CategoriaService } from './categoria.service';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html'
})
export class CategoriaComponent implements OnInit {
  categorias: Categoria[] = [];
  categoriaSeleccionada: Categoria = { id: 0, nombreCategoria: '' };
  modoEdicion: boolean = false;

  constructor(private categoriaService: CategoriaService) {}

  ngOnInit(): void {
    this.getCategorias();
  }

  getCategorias(): void {
    this.categoriaService.getAllCategorias().subscribe(categorias => {
      this.categorias = categorias;
    });
  }

  seleccionarCategoria(categoria: Categoria): void {
    this.categoriaSeleccionada = categoria;
    this.modoEdicion = true;
  }

  cancelarEdicion(): void {
    this.categoriaSeleccionada = { id: 0, nombreCategoria: '' };
    this.modoEdicion = false;
  }

  guardarCategoria(): void {
    if (this.categoriaSeleccionada.id === 0) {
    
      this.categoriaService.createCategoria(this.categoriaSeleccionada).subscribe(() => {
        this.getCategorias(); 
        this.cancelarEdicion();
      });
    } else {
      
      this.categoriaService.updateCategoria(this.categoriaSeleccionada).subscribe(() => {
        this.getCategorias(); 
        this.cancelarEdicion();
      });
    }
  }

  eliminarCategoria(id: number): void {
    this.categoriaService.deleteCategoria(id).subscribe(() => {
      this.getCategorias(); 
    });
  }
}
