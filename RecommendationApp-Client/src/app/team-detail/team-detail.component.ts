import { Component, OnInit } from '@angular/core';
import { Team } from '../_models/team';
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';
import { TeamService } from '../_services/team.service';
import { Player } from '../player';
import { PlayerService } from '../_services/player.service';
import { RecommendedPlayer } from '../recommended-player';

@Component({
  selector: 'app-team-detail',
  templateUrl: './team-detail.component.html',
  styleUrls: ['./team-detail.component.css']
})
export class TeamDetailComponent implements OnInit {
  team:Team;
  //players:Player[];
  //recommendedPlayers:RecommendedPlayer[];
  //getRecommendedPlayersButtonClicked:boolean = false;

  constructor(private route:ActivatedRoute, private location:Location, private teamService:TeamService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.team = data.team;
    });
  }

  // getTeam(){
  //   const teamId = Number.parseInt(this.route.snapshot.paramMap.get('id'));
  //   this.team = this.teamService.getTeam(teamId);
  // }

  // getPlayers(){
  //   this.players = this.playerService.getPlayers(this.team.id);
  // }

  // getRecommendedPlayers(){
  //   this.recommendedPlayers = this.playerService.getRecommendedPlayers(this.team.id);
  //   this.getRecommendedPlayersButtonClicked = true;
  // }

  goBack(){
    this.location.back();
  }
}
