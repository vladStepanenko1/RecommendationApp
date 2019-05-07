import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Player } from '../_models/player';
import { Observable, of } from 'rxjs';
import { PlayerService } from '../_services/player.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class RecommendedPlayersResolver implements Resolve<Player[]>{
    constructor(private playerService:PlayerService, private router:Router){}

    resolve(route: ActivatedRouteSnapshot): Observable<Player[]> {
        return this.playerService.getRecommendedPlayers(route.params['id']).pipe(
            catchError(error => {
                return of(null); // ?
            })
        );
    }
}