import { TestBed } from '@angular/core/testing';

import { DowloadpdfService } from './dowloadpdf.service';

describe('DowloadpdfService', () => {
  let service: DowloadpdfService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DowloadpdfService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
