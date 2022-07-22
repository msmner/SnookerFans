import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Match } from '../models/Match';

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  baseUrl = environment.apiUrl;
  headers = { 'content-type': 'application/json' };

  constructor(private httpClient: HttpClient) { }
  getMatches(): Observable<Match[]> {
    return this.httpClient.get<Match[]>(this.baseUrl + 'matches/all');
  }

  getMatch(id: string) {
    return this.httpClient.get<Match>(this.baseUrl + 'matches/' + id);
  }

  createMatch(match: any) {
    return this.httpClient.post<Match>(this.baseUrl + 'matches', JSON.stringify(match), { 'headers': this.headers });
  }

  deleteMatch(id: string) {
    return this.httpClient.delete(this.baseUrl + 'matches/' + id, { 'headers': this.headers });
  }
}
