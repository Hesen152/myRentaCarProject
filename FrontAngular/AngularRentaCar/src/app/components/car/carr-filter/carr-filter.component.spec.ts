import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarrFilterComponent } from './carr-filter.component';

describe('CarrFilterComponent', () => {
  let component: CarrFilterComponent;
  let fixture: ComponentFixture<CarrFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarrFilterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarrFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
