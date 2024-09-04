import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmpresaComponent } from './empresa/empresa.component';
import { CategoriaComponent } from './categoria/categoria.component';
import { TecnicoComponent } from './tecnico/tecnico.component';
import { ClienteComponent } from './cliente/cliente.component';
import { ConocimientoComponent } from './conocimiento/conocimiento.component';
import { ProyectoComponent } from './proyecto/proyecto.component';
import { TecnicoproyectoComponent } from './tecnicoproyecto/tecnicoproyecto.component';
import { EmpresaService } from './empresa/empresa.service';
import { CategoriaService } from './categoria/categoria.service';
import { TecnicoService } from './tecnico/tecnico.service';
import { ClienteService } from './cliente/cliente.service';
import { ConocimientoService } from './conocimiento/conocimiento.service';
import { ProyectoService } from './proyecto/proyecto.service';
import { TecnicoproyectoService } from './tecnicoproyecto/tecnicoproyecto.service';

@NgModule({
  declarations: [
    AppComponent,
    EmpresaComponent,
    CategoriaComponent,
    TecnicoComponent,
    ClienteComponent,
    ConocimientoComponent,
    ProyectoComponent,
    TecnicoproyectoComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule, 
    AppRoutingModule
  ],
  providers: [
    EmpresaService,
    CategoriaService,
    TecnicoService,
    ClienteService,
    ConocimientoService,
    ProyectoService,
    TecnicoproyectoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


