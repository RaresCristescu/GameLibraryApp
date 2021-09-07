import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { Bundle } from '../shared/bundle.model';
import { Category } from '../shared/category.model';
import { Developer } from '../shared/developer.model';
import { Game } from '../shared/game.model';
import { EditBundleModalComponent } from './edit-bundle-modal/edit-bundle-modal.component';
import { EditCategoryModalComponent } from './edit-category-modal/edit-category-modal.component';
import { EditDeveloperModalComponent } from './edit-developer-modal/edit-developer-modal.component';
import { EditGameModalComponent } from './edit-game-modal/edit-game-modal.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  games: Game[] = [];
  bundles: Bundle[] = [];
  developers: Developer[] = [];
  categories: Category[] = [];



  @ViewChild('editGameModal') editGameModal: EditGameModalComponent;
  @ViewChild('editBundleModal') editBundleModal: EditBundleModalComponent;
  @ViewChild('editDeveloperModal') editDeveloperModal: EditDeveloperModalComponent;
  @ViewChild('editCategoryModal') editCategoryModal: EditCategoryModalComponent;


  constructor(private api: ApiService) { }

  ngOnInit() {
    this.getGames();
    this.getBundles();
    this.getDevelopers();
    this.getCategories();
  }

  getGames() {
    this.api.getGames()
      .subscribe((data: Game[]) => {
        this.games = [];

        for (let i = 0; i < data.length; i++) {
          this.api.getGame(data[i].id)
            .subscribe((info: Game) => {
              info.id = data[i].id;
              this.games.push(info);
            },
              (e: Error) => {
                console.log('err', e);
              });
        }

      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  getBundles() {

    this.api.getBundles()
      .subscribe((data: Bundle[]) => {
        this.bundles = data;
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

  getCategories() {
    this.api.getCategories()
      .subscribe((data: Category[]) => {
        this.categories = data;
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  getDevelopers() {
    this.api.getDevelopers()
      .subscribe((data: Developer[]) => {
        this.developers = data;
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  deleteGame(id: number) {
    this.api.deleteGame(id)
      .subscribe(() => {
        this.games = [];
        this.getGames();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  deleteBundle(id: number) {
    this.api.deleteBundle(id)
      .subscribe(() => {
        this.getBundles();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  deleteCategory(id: number) {
    this.api.deleteCategory(id)
      .subscribe(() => {
        this.getCategories();
      },
        (error: Error) => {
          console.log(error);
        });

  }

  deleteDeveloper(id: number) {
    this.api.deleteDeveloper(id)
      .subscribe(() => {
        this.getDevelopers();
      },
        (error: Error) => {
          console.log(error);
        });

  }

  showM1(id: number): void {
    this.editGameModal.show(id);
  }

  showM2(id: number): void {
    this.editBundleModal.show(id);
  }

  showM3(id: number): void {
    this.editCategoryModal.show(id);
  }

  showM4(id: number): void {
    this.editDeveloperModal.show(id);
  }

  changeE(event: string) {
    if (event === 'game') {
      this.getGames();
    }
    if (event === 'bundle') {
      this.getBundles();
    }
    if (event === 'category') {
      this.getCategories();
    }
    if (event === 'developer') {
      this.getDevelopers();
    }

  }

}
