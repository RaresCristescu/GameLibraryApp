import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  options = ['Category', 'Developer', 'Bundle', 'Game'];
  selectedOption = 'Game';
  currentFormRef: any;
  addGameForm: FormGroup;
  addDeveloperForm: FormGroup;
  addBundleForm: FormGroup;
  addCategoryForm: FormGroup;
  success: boolean;

  constructor(public fb: FormBuilder, private api: ApiService) { }


  ngOnInit() {

    this.addGameForm = this.fb.group({
      name: [null, Validators.required],
      price: [null, Validators.required],
      description: [null, Validators.required],
      minReq: [null, Validators.required],
      recReq: [null, Validators.required],
      developerId: [null, Validators.required],
      categoryId: [null, Validators.required],
      img: [null]
    });
    this.addDeveloperForm = this.fb.group({
      name: [null, Validators.required],
      website: [null, Validators.required],
      country: [null, Validators.required]
    });
    this.addBundleForm = this.fb.group({
      name: [null, Validators.required],
      price: [null, Validators.required],
      gameId: [null, Validators.required],
      img: [null]
    });
    this.addCategoryForm = this.fb.group({
      name: [null, Validators.required]
    });

    this.currentFormRef = this.addGameForm;

  }

  radioChange(event: any) {
    this.selectedOption = event.target.value;
    this.currentFormRef = this['add' + this.selectedOption + 'Form'];
  }

  add() {
  
    this.api['add' + this.selectedOption](this.currentFormRef.value).subscribe(() => {

      this.currentFormRef.reset();
      this.success = true;
      setTimeout(() => {
        this.success = null;
      }, 3000);
    },
      (error: Error) => {
        console.log(error);
        this.currentFormRef.reset();
        this.success = false;
        setTimeout(() => {
          this.success = null;
        }, 3000);
      });

  }
}
