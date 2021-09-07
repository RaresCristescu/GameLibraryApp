import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../shared/api.service';
import { Game } from '../../shared/game.model';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-game-modal',
  templateUrl: './edit-game-modal.component.html',
  styleUrls: ['./edit-game-modal.component.css']
})
export class EditGameModalComponent {
  @ViewChild('editGameModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  editGameForm: FormGroup;
  currentGame = new Game();


  constructor(public fb: FormBuilder, private api: ApiService) { }

  show(id: number): void {
    this.modal.show();
    this.api.getGame(id)
      .subscribe((data: Game) => {
        this.currentGame = data;
        this.currentGame.id = id;
        this.initializeFrom(this.currentGame);
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  initializeFrom(currentGame: Game) {
    this.editGameForm = this.fb.group({
      name: [currentGame.name, Validators.required],
      price: [currentGame.price, Validators.required],
      description: [currentGame.description, Validators.required],
      minReq: [currentGame.minReq, Validators.required],
      recReq: [currentGame.recReq, Validators.required],
      developerId: [currentGame.developerId, Validators.required],
      categoryId: ['', Validators.required],
      img: [currentGame.img],
    });
  }

  editGame() {
    const editedGame = new Game({
      id: this.currentGame.id,
      name: this.editGameForm.value.name,
      price: this.editGameForm.value.price,
      description: this.editGameForm.value.description,
      minReq: this.editGameForm.value.minReq,
      recReq: this.editGameForm.value.recReq,
      developerId: this.editGameForm.value.developerId,
      categoryId: this.transformInNumberArray(this.editGameForm.value.categoryId),
      img: this.editGameForm.value.img
    });

    this.api.editGame(editedGame)
      .subscribe(() => {
        this.change.emit('game');
        this.modal.hide();
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

  transformInNumberArray(string: string) {
    return JSON.parse('[' + string + ']');
  }

}
