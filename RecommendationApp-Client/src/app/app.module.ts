import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeamsComponent } from './teams/teams.component';
import { RouterModule, Routes } from '@angular/router';
import {ReactiveFormsModule, FormsModule} from '@angular/forms';
import { TeamDetailComponent } from './team-detail/team-detail.component';
import { PlayersComponent } from './players/players.component';
import { HttpClientModule }    from '@angular/common/http';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TeamsResolver } from './_resolvers/teams.resolver';
import { TeamService } from './_services/team.service';
import { CountriesResolver } from './_resolvers/countries.resolver';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { TeamDetailResolver } from './_resolvers/team-detail.resolver';
import { RecommendedPlayersResolver } from './_resolvers/recommendedPlayers.resolver';
import { AlertifyService } from './_services/alertify.service';
import { PlayerDetailComponent } from './player-detail/player-detail.component';
import { PlayerDetailResolver } from './_resolvers/player-detail.resolver';
import { MapsStatComponent } from './maps-stat/maps-stat.component';
import { WeaponsStatComponent } from './weapons-stat/weapons-stat.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HelpComponent } from './help/help.component';

const routes:Routes = [
  {
    path:'',
    redirectTo:'/teams',
    pathMatch:'full'
  },
  {
    path:'teams', 
    component:TeamsComponent, 
    resolve:
    {
      teams:TeamsResolver, 
      countries:CountriesResolver
    }
  },
  {
    path:'team/:id', 
    component:TeamDetailComponent,
    resolve:
    {
      team:TeamDetailResolver,
      recommendedPlayers:RecommendedPlayersResolver
    }
  },
  {
    path:'player/:id',
    component:PlayerDetailComponent,
    resolve:
    {
      player:PlayerDetailResolver
    }
  },
  {
    path:'help',
    component:HelpComponent
  },
  {
    path:'**',
    component:PageNotFoundComponent
  }
];

@NgModule({
  declarations: [
    AppComponent,
    TeamsComponent,
    TeamDetailComponent,
    PlayersComponent,
    PlayerDetailComponent,
    MapsStatComponent,
    WeaponsStatComponent,
    PageNotFoundComponent,
    HelpComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    PaginationModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    TeamService,
    TeamsResolver,
    CountriesResolver,
    TeamDetailResolver,
    RecommendedPlayersResolver,
    ErrorInterceptorProvider,
    AlertifyService,
    PlayerDetailResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
