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
  phoneBookEntries?: PhoneBookEntry;


  constructor(
    private http: HttpClient,
    private appservice: AppService,
    // @Inject('BASE_URL') private baseUrl: string
  ) {

  }
  ngOnInit(): void {
    this.appservice.GetAllEntries()
      .subscribe(
        (successResponse) => {
          debugger
          this.phoneBookEntry = successResponse
        },
        (errorResponse) => {
          console.log(errorResponse);
        }
      );
  }
  
  RemovePhonebookEntry(phoneBookEntryId:number): void {
    this.appservice.RemovePhonebookEntry(phoneBookEntryId)
      .subscribe(
        (successResponse) => {
        },
        (errorResponse) => {
          console.log(errorResponse);
        })
  }

  SaveNewPhonebookEntry(phoneBookEntry: PhoneBookEntry) {

    this.appservice.SaveNewPhonebookEntry(phoneBookEntry)
      .subscribe(
        (successResponse) => {
        },(errorResponse) => {
          console.log(errorResponse);
        })
  }

  UpdatePhonebookEntry(phoneBookEntryId:number,phoneBookEntry:PhoneBookEntry){
   
      this.appservice.UpdatePhonebookEntry(phoneBookEntryId,phoneBookEntry)
        .subscribe(
          (successResponse) => {
            
          },
          (errorResponse) => {

          }
        )

    }

}

