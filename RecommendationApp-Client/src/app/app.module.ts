import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeamsComponent } from './teams/teams.component';
import { RouterModule, Routes } from '@angular/router';
import {ReactiveFormsModule, FormsModule} from '@angular/forms';
import { TeamDetailComponent } from './team-detail/team-detail.component';
import { PlayersComponent } from './players/players.component';
import { RecommendedPlayersComponent } from './recommended-players/recommended-players.component';
import { HttpClientModule }    from '@angular/common/http';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TeamsResolver } from './_resolvers/teams.resolver';
import { TeamService } from './team.service';

const routes:Routes = [
  {path:'teams', component:TeamsComponent, resolve:{teams:TeamsResolver}},
  {path:'team/:id', component:TeamDetailComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    TeamsComponent,
    TeamDetailComponent,
    PlayersComponent,
    RecommendedPlayersComponent
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
    TeamsResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
