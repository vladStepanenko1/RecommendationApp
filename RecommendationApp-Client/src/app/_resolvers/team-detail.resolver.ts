import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Team } from '../Team';
import { Injectable } from '@angular/core';
import { TeamService } from '../_services/team.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class TeamDetailResolver implements Resolve<Team>{
    constructor(private teamService:TeamService, private router:Router){}
    
    resolve(route:ActivatedRouteSnapshot):Observable<Team>{
        return this.teamService.getTeam(route.params['id']).pipe(
            catchError(error => {
                this.router.navigate(['/teams']);
                return of(null);
            })
        );
    }
}