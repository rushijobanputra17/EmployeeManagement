import { TestBed } from '@angular/core/testing';

import { DaraParsingService } from './dara-parsing.service';

describe('DaraParsingService', () => {
  let service: DaraParsingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DaraParsingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
