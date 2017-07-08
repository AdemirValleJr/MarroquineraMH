import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GrupoProductosComponent } from './grupo-productos.component';

describe('GrupoProductosComponent', () => {
  let component: GrupoProductosComponent;
  let fixture: ComponentFixture<GrupoProductosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GrupoProductosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GrupoProductosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
