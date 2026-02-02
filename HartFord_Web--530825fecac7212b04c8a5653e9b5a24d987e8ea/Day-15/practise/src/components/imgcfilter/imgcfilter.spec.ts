import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Imgcfilter } from './imgcfilter';

describe('Imgcfilter', () => {
  let component: Imgcfilter;
  let fixture: ComponentFixture<Imgcfilter>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Imgcfilter]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Imgcfilter);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
