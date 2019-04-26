import { Injectable } from '@angular/core';
import { Team } from './Team';
import { TEAMS } from './mock-db';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  getCountries(): string[] {
    return TEAMS.map(team => team.country);
  }

  getTeams(): Team[] {
    return TEAMS;
  }

  constructor() { }
}
