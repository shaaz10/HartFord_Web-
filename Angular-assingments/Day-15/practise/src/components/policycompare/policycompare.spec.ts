import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Policycompare } from './policycompare';

describe('Policycompare', () => {
  let component: Policycompare;
  let fixture: ComponentFixture<Policycompare>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Policycompare]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Policycompare);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
