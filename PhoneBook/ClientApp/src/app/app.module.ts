import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PhoneBookComponent } from './phone-book/phone-book.component';
import { CommonModule } from '@angular/common';
import { PhoneBookService } from './phone-book.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PhoneBookComponent,
    HomeComponent    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'phone-book', component: PhoneBookComponent }
    ])
  ],
  providers: [PhoneBookService],
  bootstrap: [AppComponent]
})
export class AppModule { }
