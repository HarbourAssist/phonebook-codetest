import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppService } from '../app.service';
import { PhoneBookEntry } from '../models/phone-book-entry';
import * as feather from 'feather-icons';

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
    this.GetAllEntries();
  }

  GetAllEntries(){
    this.appservice.GetAllEntries()
      .subscribe(
        (successResponse) => {
          console.log(successResponse);

          this.phoneBookEntries = successResponse
        },
        (errorResponse) => {
          alert(errorResponse.error);
          console.log(errorResponse);
        }
      );
  }

  SaveNewPhonebookEntry() {
    this.appservice.SaveNewPhonebookEntry(this.selectedPhoneBookEntry)
      .subscribe(
        (successResponse) => {
          alert(successResponse);
          console.log(successResponse);

          this.GetAllEntries();
          this.showTable = true;
        },
        (errorResponse) => {
          debugger
          alert(errorResponse.error);
          console.log(errorResponse);
        })
  }
  
  UpdatePhonebookEntry(){
    this.appservice.UpdatePhonebookEntry(this.selectedPhoneBookEntry.phoneBookEntryId, this.selectedPhoneBookEntry)
      .subscribe(
        (successResponse) => {
          alert(successResponse);
          console.log(successResponse);

          this.GetAllEntries();
          this.showTable = true;
        },
        (errorResponse) => {
          alert(errorResponse.error);
          console.log(errorResponse);
        }
      )
  }

  RemovePhonebookEntry(phoneBookEntryId:number) {
    this.appservice.RemovePhonebookEntry(phoneBookEntryId)
      .subscribe(
        (successResponse) => {
          alert(successResponse);
          console.log(successResponse);

          this.GetAllEntries();
        },
        (errorResponse) => {
          alert(errorResponse.error);
          console.log(errorResponse);
        })
  }

  bindSelected(phoneBookEntry:PhoneBookEntry){
    this.selectedPhoneBookEntry.phoneBookEntryId = phoneBookEntry.phoneBookEntryId;
    this.selectedPhoneBookEntry.firstname = phoneBookEntry.firstname;
    this.selectedPhoneBookEntry.surname = phoneBookEntry.surname;
    this.selectedPhoneBookEntry.phoneNumber = phoneBookEntry.phoneNumber;

    this.showTable = false;
  };

  clearSelected() {
    this.selectedPhoneBookEntry.phoneBookEntryId = 0;
    this.selectedPhoneBookEntry.firstname = "";
    this.selectedPhoneBookEntry.surname = "";
    this.selectedPhoneBookEntry.phoneNumber = "";

    this.showTable = false;
  };

}

