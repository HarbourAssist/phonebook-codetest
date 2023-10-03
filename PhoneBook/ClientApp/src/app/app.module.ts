import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PhoneBookService } from './phone-book/phone-book.service';
import { PhoneBookDetailComponent } from './phone-book/item/phone-book-item.component';
import { PhoneBookComponent } from './phone-book/list/phone-book-list.component';
import { PhoneBookFormComponent } from './phone-book/form/phone-book-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PhoneBookComponent,
    PhoneBookDetailComponent,
    PhoneBookFormComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'phone-book', component: PhoneBookComponent }
    ]),
    ReactiveFormsModule
  ],
  providers: [
    PhoneBookService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
