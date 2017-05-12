import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StockProdColorSucursalComponent } from './stock-prod-color-sucursal.component';

describe('StockProdColorSucursalComponent', () => {
  let component: StockProdColorSucursalComponent;
  let fixture: ComponentFixture<StockProdColorSucursalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StockProdColorSucursalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockProdColorSucursalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
