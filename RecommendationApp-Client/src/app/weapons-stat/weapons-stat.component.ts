import { Component, OnInit, Input } from '@angular/core';
import { WeaponStat } from '../_models/weaponStat';

@Component({
  selector: 'app-weapons-stat',
  templateUrl: './weapons-stat.component.html',
  styleUrls: ['./weapons-stat.component.css']
})
export class WeaponsStatComponent implements OnInit {

  @Input() weaponsStat:WeaponStat[];
  constructor() { }

  ngOnInit() {
  }

}
