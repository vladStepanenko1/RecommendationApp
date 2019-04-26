import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { TeamService } from '../team.service';
import { Team } from '../Team';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {

  countries:string[] = [];
  teams:Team[] = [];

  searchForm = new FormGroup({
    teamName:new FormControl(''),
    teamCountry:new FormControl('')
  });

  constructor(private teamService:TeamService) { }

  ngOnInit() {
    this.getTeams();
    this.getCountries();
  }

  getCountries() {
    this.countries = this.teamService.getCountries();
  }

  getTeams() {
    this.teams = this.teamService.getTeams();
  }

  onSubmit(){
    console.warn(this.searchForm.value);
    
  }
  resetForm(){
    this.searchForm.reset();
  }
}
