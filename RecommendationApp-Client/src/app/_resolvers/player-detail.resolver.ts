import { Player } from '../_models/player';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { PlayerService } from '../_services/player.service';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/operators';
import { messages } from '../_models/messages';
import {Location} from '@angular/common';

@Injectable()
export class PlayerDetailResolver implements Resolve<Player>{
    constructor(private playerService:PlayerService, private location:Location, private alertify:AlertifyService){}

    resolve(route:ActivatedRouteSnapshot):Observable<Player>{
        return this.playerService.getPlayer(route.params['id']).pipe(
            catchError(error => {
                console.error(error);
                
                this.alertify.error(messages.errors.problemWithRetrievingData);
                this.location.back();
                return of(null);
            })
        );
    }
}