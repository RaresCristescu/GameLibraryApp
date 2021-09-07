import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Game } from '../../shared/game.model';
import { Bundle } from '../../shared/bundle.model';
import { ApiService } from '../../shared/api.service';
import { CartService } from '../../shared/cart.service';

@Component({
  selector: 'app-detail-modal',
  templateUrl: './detail-modal.component.html',
  styleUrls: ['./detail-modal.component.css']
})
export class DetailModalComponent implements OnInit {
  @ViewChild('detailModal') modal: ModalDirective;
  game = new Game();
  developer: string;
  isLoggedIn: string;

  constructor(private api: ApiService, private cart: CartService) { }

  ngOnInit() {}

  show(id: number): void {
    this.getGame(id);
    this.modal.show();
  }

  getDeveloper(id: number) {
    this.api.getDeveloper(id)
      .subscribe((data: Game) => {
        this.developer = data.name;
      },
        (err: Error) => {
          console.log('err', err);

        });
  }

  getGame(id: number) {
    this.api.getGame(id)
      .subscribe((data: Game) => {
        this.game = data;
        this.game.id = id;
        if (!data.img) {
          this.game.img = 'https://i.ibb.co/vHP0qCz/game-ratings-featured.jpg';
        }
        this.getDeveloper(this.game.developerId);
      },
        (err: Error) => {
          console.log('err', err);

        });
  }

  addCart(game: Game) {
    this.cart.add(game);
    this.modal.hide();
  }
}
