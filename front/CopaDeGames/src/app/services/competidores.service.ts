import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Competidores } from '../models/competidor.model';

const url = 'https://l3-processoseletivo.azurewebsites.net/api/Competidores?copa=games';

@Injectable({
  providedIn: 'root'
})

export class CompetidoresService {

  constructor(private httpClient: HttpClient) { }

  list(): Observable<Competidores>{
    return this.httpClient.get<Competidores>(url);
  }
}
