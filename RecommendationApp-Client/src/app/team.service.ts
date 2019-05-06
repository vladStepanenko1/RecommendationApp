import { Injectable } from '@angular/core';
import { Team } from './Team';
import { TEAMS } from './mock-db';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginatedResult } from './_models/pagination';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  baseUrl = environment.apiUrl;

  getTeam(teamId: number): Team {
    return TEAMS.find(team => team.id === teamId);
  }

  getCountries(): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + 'countries', {observe:'response'})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getTeams(page?, itemsPerPage?, teamParams?): Observable<PaginatedResult<Team[]>> {
    const paginatedResult: PaginatedResult<Team[]> = new PaginatedResult<Team[]>();
    let params = new HttpParams();

    if(page != null && itemsPerPage != null){
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if(teamParams != null){
      params = params.append('name', teamParams.name);
      params = params.append('country', teamParams.country);
      params = params.append('minRating', teamParams.minRating);
      params = params.append('maxRating', teamParams.maxRating);
    }

    return this.http.get<Team[]>(this.baseUrl + 'teams', {observe:'response', params})
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if(response.headers.get('Pagination') != null){
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }

  constructor(private http:HttpClient) { }
}
