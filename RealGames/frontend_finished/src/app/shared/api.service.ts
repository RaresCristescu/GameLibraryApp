import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Developer } from './developer.model';
import { Game } from './game.model';
import { Bundle } from './bundle.model';
import { Category } from './category.model';
//import { privateDecrypt } from 'crypto';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {}

  header = new HttpHeaders({
    'Content-Type': 'application/json'
  });
  baseUrl = 'https://localhost:44344/api';

  addGame(game) {
    return this.http.post(this.baseUrl + '/game', 
    
    {
      'name': game.name,
      'price': game.price,
      'description': game.description,
      'minReq': game.minReq,
      'recReq': game.recReq,
      'developerId': game.developerId,
      'CategoryId': JSON.parse('[' + game.categoryId + ']'),
    }, { headers: this.header });

  }

  addDeveloper(developer: Developer) {
    return this.http.post(this.baseUrl + '/developer', developer, { headers: this.header });
  }

  addBundle(bundle) {
    return this.http.post(this.baseUrl + '/bundle', {
      'name': bundle.name,
      'price': bundle.price,
      'GameId': JSON.parse('[' + bundle.gameId + ']'),
      'img': bundle.img
    }, { headers: this.header });


  }



  getBundle(id: number) {
    return this.http.get(this.baseUrl + '/bundle/' + id.toString(), { headers: this.header });
  }

  getGame(id: number) {
    return this.http.get(this.baseUrl + '/game/' + id.toString(), { headers: this.header });
  }

  getDeveloper(id: number) {
    return this.http.get(this.baseUrl + '/developer/' + id.toString(), { headers: this.header });
  }

  getCategory(id: number) {
    return this.http.get(this.baseUrl + '/category/' + id.toString(), { headers: this.header });
  }

  getBundles() {
    return this.http.get(this.baseUrl + '/bundle', { headers: this.header });
  }

  getGames() {
    return this.http.get(this.baseUrl + '/game', { headers: this.header });
  }

  getDevelopers() {
    return this.http.get(this.baseUrl + '/developer', { headers: this.header });
  }

  getCategories() {
    return this.http.get(this.baseUrl + '/category', { headers: this.header });
  }



  deleteGame(id: number) {
    return this.http.delete(this.baseUrl + '/game/' + id.toString(), { headers: this.header });
  }

  deleteBundle(id: number) {
    return this.http.delete(this.baseUrl + '/bundle/' + id.toString(), { headers: this.header });
  }

  deleteCategory(id: number) {
    return this.http.delete(this.baseUrl + '/category/' + id.toString(), { headers: this.header });
  }

  deleteDeveloper(id: number) {
    return this.http.delete(this.baseUrl + '/developer/' + id.toString(), { headers: this.header });
  }



  editBundle(bundle: Bundle) {

    return this.http.put(this.baseUrl + '/bundle/' + bundle.id.toString(), bundle, { headers: this.header });
  }

  editDeveloper(developer: Developer) {
    return this.http.put(this.baseUrl + '/developer/' + developer.id.toString(), developer, { headers: this.header });
  }

  editGame(game: Game) {
    return this.http.put(this.baseUrl + '/game/' + game.id.toString(), game, { headers: this.header });
  }

  editCategory(category: Category) {
    return this.http.put(this.baseUrl + '/category/' + category.id.toString(), category, { headers: this.header });
  }


}

