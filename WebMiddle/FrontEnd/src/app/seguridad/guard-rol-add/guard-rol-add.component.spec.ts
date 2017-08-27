import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GuardRolAddComponent } from './guard-rol-add.component';

describe('GuardRolAddComponent', () => {
  let component: GuardRolAddComponent;
  let fixture: ComponentFixture<GuardRolAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GuardRolAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GuardRolAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
