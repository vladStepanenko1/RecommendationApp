import { Injectable } from '@angular/core';
import { PLAYERS, RECOMMENDED_PLAYERS } from '../mock-db';
import { Player } from '../player';
import { RecommendedPlayer } from '../recommended-player';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  getRecommendedPlayers(teamId: number): RecommendedPlayer[] {
    return RECOMMENDED_PLAYERS.sort((p1, p2) => p2.calculatedRating - p1.calculatedRating);
  }

  getPlayers(teamId: number): Player[] {
    return PLAYERS.filter(player => player.teamId === teamId);
  }

  constructor() { }
}
