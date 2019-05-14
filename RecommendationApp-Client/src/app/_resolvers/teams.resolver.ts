import { Injectable } from "@angular/core";
import { Team } from '../_models/team';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { TeamService } from '../_services/team.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { messages } from '../_models/messages';

@Injectable()
export class TeamsResolver implements Resolve<Team[]>{
    constructor(private teamService:TeamService, private router:Router, private alertify:AlertifyService){}
    
    resolve(route:ActivatedRouteSnapshot):Observable<Team[]>{
        return this.teamService.getTeams().pipe(
            catchError(error => {
                console.error(error);
                
                this.alertify.error(messages.errors.problemWithRetrievingData);
                this.router.navigate(['/']);
                return of(null);
            })
        );
    }
}