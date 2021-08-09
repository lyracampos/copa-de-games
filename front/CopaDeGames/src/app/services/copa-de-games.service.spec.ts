import { TestBed } from '@angular/core/testing';

import { CopaDeGamesService } from './copa-de-games.service';

describe('CopaDeGamesService', () => {
  let service: CopaDeGamesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CopaDeGamesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
