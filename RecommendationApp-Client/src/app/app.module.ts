import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeamsComponent } from './teams/teams.component';
import { RouterModule, Routes } from '@angular/router';
import {ReactiveFormsModule} from '@angular/forms';
import { TeamDetailComponent } from './team-detail/team-detail.component';
import { PlayersComponent } from './players/players.component';
import { RecommendedPlayersComponent } from './recommended-players/recommended-players.component';

const routes:Routes = [
  {path:'teams', component:TeamsComponent},
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
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
