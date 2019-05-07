import { Injectable } from '@angular/core';
import { Player } from '../_models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  getRecommendedPlayers(teamId: number): Player[] {
    throw new Error("Not implemented");
  }
  
  constructor() { }
}
