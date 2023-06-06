import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppService } from '../app.service';
import { PhoneBookEntry } from '../models/phone-book-entry';

@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css']
})
export class PhoneBookComponent {
  phoneBookEntry: PhoneBookEntry[] = [];


  constructor(
    private http: HttpClient,
    private appservice: AppService,
    // @Inject('BASE_URL') private baseUrl: string
  ) {
    
  }
  ngOnInit(): void {
    // fetch Students
    this.appservice.GetAllEntries()
    .subscribe(                               
      (successResponse) => {

       this.phoneBookEntry = successResponse 
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
  }
}

