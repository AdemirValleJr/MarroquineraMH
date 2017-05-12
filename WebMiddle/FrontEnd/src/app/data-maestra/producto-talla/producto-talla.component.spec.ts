import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoTallaComponent } from './producto-talla.component';

describe('ProductoTallaComponent', () => {
  let component: ProductoTallaComponent;
  let fixture: ComponentFixture<ProductoTallaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductoTallaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductoTallaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
