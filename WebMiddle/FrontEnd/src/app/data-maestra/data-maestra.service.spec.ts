import { TestBed, inject } from '@angular/core/testing';

import { DataMaestraService } from './data-maestra.service';

describe('DataMaestraService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DataMaestraService]
    });
  });

  it('should ...', inject([DataMaestraService], (service: DataMaestraService) => {
    expect(service).toBeTruthy();
  }));
});
