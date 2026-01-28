import { TestBed } from '@angular/core/testing';

import { Calci } from './calci';

describe('Calci', () => {
  let service: Calci;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Calci);
  });

  it('should add two numbers',()=>{
    let res=service.add(2,3);
    expect(res).toBe(5);
  })

  it('should subtract two numbers',()=>{
    let res=service.sub(2,3);
    expect(res).toBe(-1);
  })

  it('should multiply two numbers',()=>{
    let res=service.mul(2,3);
    expect(res).toBe(6);
  })

  it('should divide two numbers',()=>{
    let res=service.div(6,3);
    expect(res).toBe(2);
  })

  it('should find remainder',()=>{
    let res=service.mod(2,3);
    expect(res).toBe(2);
  })

});
