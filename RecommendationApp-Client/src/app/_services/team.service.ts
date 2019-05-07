import { Injectable } from '@angular/core';
import { Team } from '../_models/team';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginatedResult } from '../_models/pagination';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  baseUrl = environment.apiUrl;

  getTeam(teamId: number): Observable<Team> {
    return this.http.get<Team>(this.baseUrl + 'teams/' + teamId, {observe:'response'})
      .pipe(
        map(response => {
          return response.body;
        })
      );
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
      if(teamParams.name){
        params = params.append('name', teamParams.name);
      }

      if(teamParams.country){
        params = params.append('country', teamParams.country);
      }

      if(teamParams.minRating){
        params = params.append('minRating', teamParams.minRating);
      }

      if(teamParams.maxRating){
        params = params.append('maxRating', teamParams.maxRating);
      }
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
