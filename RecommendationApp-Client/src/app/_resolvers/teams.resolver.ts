import { Injectable } from "@angular/core";
import { Team } from '../Team';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { TeamService } from '../team.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class TeamsResolver implements Resolve<Team[]>{
    constructor(private teamService:TeamService, private router:Router){}
    
    resolve(route:ActivatedRouteSnapshot):Observable<Team[]>{
        return this.teamService.getTeams().pipe(
            catchError(error => {
                this.router.navigate(['/']);
                return of(null);
            })
        )
    }
}