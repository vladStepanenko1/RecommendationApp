import { Component, OnInit, Input } from '@angular/core';
import { MapStat } from '../_models/mapStat';

@Component({
  selector: 'app-maps-stat',
  templateUrl: './maps-stat.component.html',
  styleUrls: ['./maps-stat.component.css']
})
export class MapsStatComponent implements OnInit {

  @Input() mapsStat:MapStat[];
  constructor() { }

  ngOnInit() {
  }

}
