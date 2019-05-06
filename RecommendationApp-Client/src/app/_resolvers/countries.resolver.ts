import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { TeamService } from '../team.service';
import { Observable } from 'rxjs';

@Injectable()
export class CountriesResolver implements Resolve<string[]>{
    constructor(private teamService:TeamService){}

    resolve(route:ActivatedRouteSnapshot):Observable<string[]>{
        return this.teamService.getCountries();
    }
}