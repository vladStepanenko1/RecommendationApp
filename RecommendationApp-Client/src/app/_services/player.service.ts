import { Injectable } from '@angular/core';
import { Player } from '../_models/player';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
    getPlayer(playerId:number) {
      return this.http.get<Player>(`${this.baseUrl}players/${playerId}`, {observe:'response'}).pipe(
        map(response => {
          return response.body;
        })
      );
    }

  baseUrl = environment.apiUrl;

  getRecommendedPlayers(teamId: number): Observable<Player[]> {
    return this.http.get<Player[]>(this.baseUrl + 'teams/' + teamId + '/recommendedPlayers', 
      {observe:'response'}).pipe(
        map(response => {
          return response.body;
        })
      );
  }
  
  constructor(private http:HttpClient) { }
}
