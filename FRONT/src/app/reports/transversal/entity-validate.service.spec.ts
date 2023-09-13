import { TestBed } from '@angular/core/testing';

import { EntityValidateService } from './entity-validate.service';

describe('EntityValidateService', () => {
  let service: EntityValidateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EntityValidateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
