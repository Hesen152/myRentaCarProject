import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectedListBrandComponent } from './selected-list-brand.component';

describe('SelectedListBrandComponent', () => {
  let component: SelectedListBrandComponent;
  let fixture: ComponentFixture<SelectedListBrandComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectedListBrandComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectedListBrandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
