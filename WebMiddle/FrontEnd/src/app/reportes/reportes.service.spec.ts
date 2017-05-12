import { TestBed, inject } from '@angular/core/testing';

import { ReportesService } from './reportes.service';

describe('ReportesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReportesService]
    });
  });

  it('should ...', inject([ReportesService], (service: ReportesService) => {
    expect(service).toBeTruthy();
  }));
});
