import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RedTiendasComponent } from './red-tiendas.component';

describe('RedTiendasComponent', () => {
  let component: RedTiendasComponent;
  let fixture: ComponentFixture<RedTiendasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RedTiendasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RedTiendasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
