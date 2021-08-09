import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Campeonato } from '../models/campeonato.model';
import { Competidores } from '../models/competidor.model';

@Injectable({
  providedIn: 'root'
})
export class CopaDeGamesService {

  resultado: string = '';
  baseUrl = 'http://localhost:5000/api/campeonato';

  constructor(private http: HttpClient) { }

  getCompetidoresApiLambda(): Observable<Competidores> {
    return this.http.get<Competidores>("https://l3-processoseletivo.azurewebsites.net/api/Competidores?copa=games");
  }

  iniciarCampeonato(data: string[]): Observable<Campeonato> {
    const headers = { 'content-type': 'application/json', 'accept':'application/json'} 
    const body=JSON.stringify(data);
    return this.http.post<Campeonato>(this.baseUrl, body ,{'headers':headers});
  }

  getCampeonato(id: string): Observable<Campeonato> {
    return this.http.get<Campeonato>(`${this.baseUrl}/${id}`);
  }
}