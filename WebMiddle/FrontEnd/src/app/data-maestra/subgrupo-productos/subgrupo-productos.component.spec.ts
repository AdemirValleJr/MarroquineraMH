import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubgrupoProductosComponent } from './subgrupo-productos.component';

describe('SubgrupoProductosComponent', () => {
  let component: SubgrupoProductosComponent;
  let fixture: ComponentFixture<SubgrupoProductosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubgrupoProductosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubgrupoProductosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
