import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeamsComponent } from './teams/teams.component';
import { RouterModule, Routes } from '@angular/router';
import {ReactiveFormsModule} from '@angular/forms';

const routes:Routes = [
  {path:'teams', component:TeamsComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    TeamsComponent
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
