import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StockProdColorSucursalDetalleComponent } from './stock-prod-color-sucursal-detalle.component';

describe('StockProdColorSucursalDetalleComponent', () => {
  let component: StockProdColorSucursalDetalleComponent;
  let fixture: ComponentFixture<StockProdColorSucursalDetalleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StockProdColorSucursalDetalleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockProdColorSucursalDetalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
