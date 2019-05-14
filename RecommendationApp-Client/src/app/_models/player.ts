import { MapStat } from './mapStat';
import { WeaponStat } from './weaponStat';

export interface Player{
    id:number;
    gender:string;
    country:string;
    averageRating:number;
    age:number;
    totalTimePlayed:number;
    totalWins:number;
    totalRoundsPlayed;
    totalKills:number;
    totalDeaths:number;
    mapsStats:MapStat[];
    weaponsStats:WeaponStat[];
}