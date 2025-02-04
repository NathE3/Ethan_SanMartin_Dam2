import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FerrariComponent } from './ferrari.component';

describe('FerrariComponent', () => {
  let component: FerrariComponent;
  let fixture: ComponentFixture<FerrariComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FerrariComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FerrariComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
