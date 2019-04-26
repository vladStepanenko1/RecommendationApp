import { Component, OnInit, Input } from '@angular/core';
import { RecommendedPlayer } from '../recommended-player';

@Component({
  selector: 'app-recommended-players',
  templateUrl: './recommended-players.component.html',
  styleUrls: ['./recommended-players.component.css']
})
export class RecommendedPlayersComponent implements OnInit {

  @Input() players:RecommendedPlayer[];

  constructor() { }

  ngOnInit() {
  }

}
