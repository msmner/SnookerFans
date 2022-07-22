import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Player } from '../models/Player';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Match } from '../models/Match';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  baseUrl = environment.apiUrl;
  headers = { 'content-type': 'application/json' };

  constructor(private httpClient: HttpClient) { }

  getPlayers(): Observable<Player[]> {
    return this.httpClient.get<Player[]>(this.baseUrl + 'players');
  }

  getPlayer(username: string): Observable<Player> {
    return this.httpClient.get<Player>(this.baseUrl + 'players/' + username);
  }

  createPlayer(player: any) {
    return this.httpClient.post<Player>(this.baseUrl + 'players', JSON.stringify(player), { 'headers': this.headers });
  }

  deletePlayer(username: string) {
    return this.httpClient.delete(this.baseUrl + 'players/' + username, {'headers': this.headers});
  }

  updatePlayer(username: string, data: any) {
    return this.httpClient.put<Player>(this.baseUrl + 'players/' + username, JSON.stringify(data), {'headers': this.headers});
  }

  getPlayersMatches(username: string) :Observable<Match[]> {
    return this.httpClient.get<Match[]>(this.baseUrl + `players/${username}/matches`);
  }
}
