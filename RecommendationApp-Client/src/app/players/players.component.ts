import { Component, OnInit, Input } from '@angular/core';
import { Player } from '../_models/player';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {

  @Input() players:Player[];
  @Input() tableName:string;

  constructor() { }

  ngOnInit() {
  }

}
