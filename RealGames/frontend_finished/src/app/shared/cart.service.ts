
import {Injectable} from '@angular/core';
import {Game} from './game.model';
import {Bundle} from './bundle.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  games: Game[] =[];


  constructor() {

  }

  add(game: Game){
    this.games.push(game);

  }

  get() {
    return this.games;
  }


}
