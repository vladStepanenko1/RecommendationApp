import { Team } from "./team";
import {Player} from "./player";
import { RecommendedPlayer } from './recommended-player';

const TEAMS: Team[] = [
    {
        id: 1,
        name:"T1",
        country:"C1",
        about: "about1",
        rating:1,
        ownerId:1
      },
      {
        id: 2,
        name:"T2",
        country:"C2",
        about: "about2",
        rating:2,
        ownerId:2
      },
      {
        id: 3,
        name:"T3",
        country:"C3",
        about: "about3",
        rating:3,
        ownerId:3
      },
      {
        id: 4,
        name:"T4",
        country:"C4",
        about: "about4",
        rating:4,
        ownerId:4
      },
      {
        id: 5,
        name:"T5",
        country:"C5",
        about: "about5",
        rating:5,
        ownerId:5
      }
];

const PLAYERS: Player[] = [
  {
    id:1,
    gender:"M",
    country:"ua",
    teamId:1
  },
  {
    id:2,
    gender:"M",
    country:"ua",
    teamId:2
  },
  {
    id:3,
    gender:"M",
    country:"ua",
    teamId:3
  },
  {
    id:4,
    gender:"M",
    country:"ua",
    teamId:2
  },
  {
    id:5,
    gender:"M",
    country:"ua",
    teamId:1
  },
  {
    id:6,
    gender:"M",
    country:"ua",
    teamId:2
  },
];

const RECOMMENDED_PLAYERS: RecommendedPlayer[] = [
  {
    id:101,
    gender:"M",
    country:"ua",
    calculatedRating:3.5,
    teamId:null
  },
  {
    id:102,
    gender:"M",
    country:"ua",
    calculatedRating:2.7,
    teamId:null
  },
  {
    id:103,
    gender:"M",
    country:"ua",
    calculatedRating:9.3,
    teamId:null
  },
  {
    id:104,
    gender:"M",
    country:"ua",
    calculatedRating:3.3,
    teamId:null
  },
  {
    id:105,
    gender:"M",
    country:"ua",
    calculatedRating:8.8,
    teamId:null
  },
  {
    id:106,
    gender:"M",
    country:"ua",
    calculatedRating:5.6,
    teamId:null
  },
];

export {TEAMS, PLAYERS, RECOMMENDED_PLAYERS};