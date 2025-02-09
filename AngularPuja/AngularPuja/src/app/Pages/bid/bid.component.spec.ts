import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BidComponent } from './bid.component';

describe('BidComponent', () => {
  let component: BidComponent;
  let fixture: ComponentFixture<BidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BidComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
