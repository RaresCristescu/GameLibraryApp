import { Component, OnInit, ViewChild } from '@angular/core';
import { Game } from '../shared/game.model';
import { Bundle } from '../shared/bundle.model';
import { DetailModalComponent } from './detail-modal/detail-modal.component';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  games: Game[] = [];
  bundles: Bundle[] =[];
  searchText: string;
  title: string;

  @ViewChild('detailModal') detailModal: DetailModalComponent;


  constructor(private api: ApiService) { }

  ngOnInit() {
    this.api.getGames().subscribe((data: Game[]) => {

      for (let i = 0; i < data.length; i++) {
        this.api.getGame(data[i].id).subscribe((info: Game) => {
          info.id = data[i].id;
          if (!info.img) {
            info.img = 'https://i.ibb.co/vHP0qCz/game-ratings-featured.jpg';
          }
        
          this.games.push(info);
        },
          (e: Error) => {
            console.log('err', e);
          });
      }
    },  
      (er: Error) => {
        console.log('err', er);
      });
  }

  showDM(id: number): void {
    this.detailModal.show(id);
  }
}
