import { Injectable } from '@angular/core';
import { Team } from './Team';
import { TEAMS } from './mock-db';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  getTeam(teamId: number): Team {
    return TEAMS.find(team => team.id === teamId);
  }

  getCountries(): string[] {
    return TEAMS.map(team => team.country);
  }

  getTeams(): Team[] {
    return TEAMS;
  }

  constructor() { }
}
