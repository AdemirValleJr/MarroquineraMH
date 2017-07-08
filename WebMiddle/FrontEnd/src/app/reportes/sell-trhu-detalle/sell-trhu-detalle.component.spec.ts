import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SellTrhuDetalleComponent } from './sell-trhu-detalle.component';

describe('SellTrhuDetalleComponent', () => {
  let component: SellTrhuDetalleComponent;
  let fixture: ComponentFixture<SellTrhuDetalleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SellTrhuDetalleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SellTrhuDetalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
