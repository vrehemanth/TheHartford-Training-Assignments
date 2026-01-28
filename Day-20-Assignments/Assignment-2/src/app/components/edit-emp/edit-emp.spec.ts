import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEmp } from './edit-emp';

describe('EditEmp', () => {
  let component: EditEmp;
  let fixture: ComponentFixture<EditEmp>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditEmp]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditEmp);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
