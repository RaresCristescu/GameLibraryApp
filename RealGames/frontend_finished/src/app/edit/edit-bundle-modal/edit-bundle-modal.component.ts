import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Bundle } from '../../shared/bundle.model';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-edit-bundle-modal',
  templateUrl: './edit-bundle-modal.component.html',
  styleUrls: ['./edit-bundle-modal.component.css']
})
export class EditBundleModalComponent {
  @ViewChild('editBundleModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  editBundleForm: FormGroup;
  currentBundle = new Bundle();

  constructor(public fb: FormBuilder, private api: ApiService) {}

  show(id: number): void {

    this.modal.show();
    this.api.getBundle(id)
      .subscribe((data: Bundle) => {
        this.currentBundle = data;
        this.initializeFrom(this.currentBundle);
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

  initializeFrom(currentBundle: Bundle) {
    this.editBundleForm = this.fb.group({
      name: [currentBundle.name, Validators.required],
      price: [currentBundle.price, Validators.required],
      gameId: ['', Validators.required],
      img: [currentBundle.img],
    });
  }

  editBundle() {
    const editedBundle = new Bundle({
      id: this.currentBundle.id,
      name: this.editBundleForm.value.name,
      price: this.editBundleForm.value.style,
      gameId: this.transformInNumberArray(this.editBundleForm.value.gameId),
      img: this.editBundleForm.value.img
    });

    this.api.editBundle(editedBundle)
      .subscribe(() => {
        this.change.emit('bundle');
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
