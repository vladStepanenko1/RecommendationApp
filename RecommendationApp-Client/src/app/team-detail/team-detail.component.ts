import { Component, OnInit } from '@angular/core';
import { Team } from '../_models/team';
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';
import { Player } from '../_models/player';

@Component({
  selector: 'app-team-detail',
  templateUrl: './team-detail.component.html',
  styleUrls: ['./team-detail.component.css']
})
export class TeamDetailComponent implements OnInit {
  team:Team;
  playersTableName:string;
  recommendedPlayersTableName:string;
  recommendedPlayers:Player[];

  constructor(private route:ActivatedRoute, private location:Location) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.team = data.team;
    });
    this.playersTableName = "Гравці команди";
    this.recommendedPlayersTableName = "Рекомендовані гравці";
  }

  goBack(){
    this.location.back();
  }
}
