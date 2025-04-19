import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TecnicoproyectoComponent } from './tecnicoproyecto.component';

describe('TecnicoproyectoComponent', () => {
  let component: TecnicoproyectoComponent;
  let fixture: ComponentFixture<TecnicoproyectoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TecnicoproyectoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TecnicoproyectoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
