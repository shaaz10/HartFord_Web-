import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Insurancecalc } from './insurancecalc';

describe('Insurancecalc', () => {
  let component: Insurancecalc;
  let fixture: ComponentFixture<Insurancecalc>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Insurancecalc]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Insurancecalc);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
