import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { TeamService } from '../_services/team.service';
import { Observable } from 'rxjs';

@Injectable()
export class CountriesResolver implements Resolve<string[]>{
    constructor(private teamService:TeamService){}

    resolve(route:ActivatedRouteSnapshot):Observable<string[]>{
        return this.teamService.getCountries();
    }
}