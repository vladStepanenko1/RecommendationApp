import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';
import { Player } from '../_models/player';

@Component({
  selector: 'app-player-detail',
  templateUrl: './player-detail.component.html',
  styleUrls: ['./player-detail.component.css']
})
export class PlayerDetailComponent implements OnInit {
  player:Player;

  constructor(private route:ActivatedRoute, private location:Location) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.player = data.player;
    });
  }

  goBack(){
    this.location.back();
  }
}
