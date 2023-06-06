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
  phoneBookEntries: PhoneBookEntry[] = [];

  selectedPhoneBookEntry: PhoneBookEntry = {
    phoneBookEntryId: 0,
    firstname: "",
    surname: "",
    phoneNumber: "",
  };

  showTable = true;

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
          this.phoneBookEntries = successResponse
        },
        (errorResponse) => {
          console.log(errorResponse);
        }
      );
  }
  
  RemovePhonebookEntry(phoneBookEntryId:number) {
    debugger
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

    bindSelected(phoneBookEntry:PhoneBookEntry){
      debugger
      this.selectedPhoneBookEntry.phoneBookEntryId = phoneBookEntry.phoneBookEntryId;
      this.selectedPhoneBookEntry.firstname = phoneBookEntry.firstname;
      this.selectedPhoneBookEntry.surname = phoneBookEntry.surname;
      this.selectedPhoneBookEntry.phoneNumber = phoneBookEntry.phoneNumber;

      this.showTable = false;
    };

}

