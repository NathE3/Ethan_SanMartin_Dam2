import { TestBed } from '@angular/core/testing';

import { FerrarisService } from './ferrari-service.service';

describe('FerrariService', () => {
  let service: FerrarisService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FerrarisService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
