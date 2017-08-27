import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GuardRolListComponent } from './guard-rol-list.component';

describe('GuardRolListComponent', () => {
  let component: GuardRolListComponent;
  let fixture: ComponentFixture<GuardRolListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GuardRolListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GuardRolListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
