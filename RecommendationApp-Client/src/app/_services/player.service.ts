import { Injectable } from '@angular/core';
import { Player } from '../player';
import { RecommendedPlayer } from '../recommended-player';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  getRecommendedPlayers(teamId: number): RecommendedPlayer[] {
    throw new Error("Not implemented");
  }

  getPlayers(teamId: number): Player[] {
    throw new Error("Not implemented");
  }
  
  constructor() { }
}
