import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { TeamService } from '../team.service';
import { Team } from '../Team';
import { Pagination, PaginatedResult } from '../_models/pagination';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  countries:string[] = [];
  teams:Team[];
  pagination:Pagination;
  teamParams:any = {};

  pageNumber = 1;
  pageSize = 5;
  maxSize = 10;

  searchForm = new FormGroup({
    teamName:new FormControl(''),
    teamCountry:new FormControl(''),
    teamMinRating:new FormControl(''),
    teamMaxRating:new FormControl('')
  });

  constructor(private teamService:TeamService, private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.teams = data.teams.result;
      this.pagination = data.teams.pagination;
      console.log(data);
      
    });
  }

  // getCountries() {
  //   this.countries = this.teamService.getCountries();
  // }

  getTeams() {
    this.teamService.getTeams(this.pagination.currentPage, this.pagination.itemsPerPage, this.teamParams)
    .subscribe(
      (res:PaginatedResult<Team[]>) => {
      this.teams = res.result;
      this.pagination = res.pagination;
    },
    error => {
      // TODO
    });
  }

  pageChanged(event:any):void{
    this.pagination.currentPage = event.page;
    this.getTeams();
  }

  onSubmit(){
    console.warn(this.searchForm.value);
    this.teamParams.name = this.searchForm.get('teamName').value;
    this.teamParams.country = this.searchForm.get('teamCountry').value;
    this.teamParams.minRating = this.searchForm.get('teamMinRating').value;
    this.teamParams.maxRating = this.searchForm.get('teamMaxRating').value;

    this.getTeams();
  }

  resetForm(){
    this.searchForm.reset();

    this.teamParams.name = this.searchForm.get('teamName').value;
    this.teamParams.country = this.searchForm.get('teamCountry').value;
    this.teamParams.minRating = this.searchForm.get('teamMinRating').value;
    this.teamParams.maxRating = this.searchForm.get('teamMaxRating').value;
    
    this.getTeams();
  }
}
