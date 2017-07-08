import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SellTrhuComponent } from './sell-trhu.component';

describe('SellTrhuComponent', () => {
  let component: SellTrhuComponent;
  let fixture: ComponentFixture<SellTrhuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SellTrhuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SellTrhuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
