import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowEmpById } from './show-emp-by-id';

describe('ShowEmpById', () => {
  let component: ShowEmpById;
  let fixture: ComponentFixture<ShowEmpById>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShowEmpById]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowEmpById);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
