import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import {HttpClientModule} from '@angular/common/http';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { EditGameModalComponent } from './edit/edit-game-modal/edit-game-modal.component';
import { EditBundleModalComponent } from './edit/edit-bundle-modal/edit-bundle-modal.component';
import { EditCategoryModalComponent } from './edit/edit-category-modal/edit-category-modal.component';
import { EditDeveloperModalComponent } from './edit/edit-developer-modal/edit-developer-modal.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HomeComponent } from './home/home.component';
import { SearchPipe } from './shared/search.pipe';
import { DetailModalComponent } from './home/detail-modal/detail-modal.component';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { CartModalComponent } from './header/cart-modal/cart-modal.component';


@NgModule({
  declarations: [
    AppComponent,
    AddComponent,
    EditComponent,
    EditGameModalComponent,
    EditBundleModalComponent,
    EditCategoryModalComponent,
    EditDeveloperModalComponent,
    HomeComponent,
    SearchPipe,
    DetailModalComponent,
    HeaderComponent,
    CartModalComponent,
    EditBundleModalComponent,
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
