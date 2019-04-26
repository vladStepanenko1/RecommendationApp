import { Component, OnInit } from '@angular/core';
import { Team } from '../Team';
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';
import { TeamService } from '../team.service';

@Component({
  selector: 'app-team-detail',
  templateUrl: './team-detail.component.html',
  styleUrls: ['./team-detail.component.css']
})
export class TeamDetailComponent implements OnInit {

  team:Team;

  constructor(private route:ActivatedRoute, private location:Location, private teamService:TeamService) { }

  ngOnInit() {
    this.getTeam();
  }

  getTeam(){
    const teamId = Number.parseInt(this.route.snapshot.paramMap.get('id'));
    this.team = this.teamService.getTeam(teamId);
  }

  getRecommendedPlayers(){
    //TODO
  }

  goBack(){
    this.location.back();
  }
}
