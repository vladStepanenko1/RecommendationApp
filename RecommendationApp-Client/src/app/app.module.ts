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

const routes:Routes = [
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
      team:TeamDetailResolver
    }
  }
];

@NgModule({
  declarations: [
    AppComponent,
    TeamsComponent,
    TeamDetailComponent,
    PlayersComponent,
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
    ErrorInterceptorProvider,
    TeamService,
    TeamsResolver,
    CountriesResolver,
    TeamDetailResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
