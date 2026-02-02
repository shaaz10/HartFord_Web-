import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Imgchange } from './imgchange';

describe('Imgchange', () => {
  let component: Imgchange;
  let fixture: ComponentFixture<Imgchange>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Imgchange]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Imgchange);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
