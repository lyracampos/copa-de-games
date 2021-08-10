import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Campeonato } from '../models/campeonato.model';

const urlApi = 'http://localhost:5000/api/campeonato';

@Injectable({
  providedIn: 'root'
})
export class CampeonatoService {

  constructor(private httpClient: HttpClient) { }

  iniciarCampeonato(competidores: string[]): Observable<Campeonato> {
    const headers = { 'content-type': 'application/json', 'accept':'application/json'};
    const body =JSON.stringify(competidores);
    return this.httpClient.post<Campeonato>(urlApi, body, {'headers':headers});
  }

  buscarCampeonato(id: string): Observable<Campeonato> {
    return this.httpClient.get<Campeonato>(`${urlApi}/${id}`);
  }
}
