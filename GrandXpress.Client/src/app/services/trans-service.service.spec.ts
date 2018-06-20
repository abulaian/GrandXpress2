import { TestBed, inject } from '@angular/core/testing';

import { TransServiceService } from './trans-service.service';

describe('TransServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TransServiceService]
    });
  });

  it('should be created', inject([TransServiceService], (service: TransServiceService) => {
    expect(service).toBeTruthy();
  }));
});
