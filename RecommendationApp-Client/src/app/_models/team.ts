import { Player } from '../player';
import { BestMap } from './bestMap';

export interface Team{
    profileId: number;
    name:string;
    country:string;
    about:string;
    rating:number;
    //createdAt:?
    players:Player[],
    bestMaps:BestMap[]
}