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
    this.GetAllEntries();
  }

  GetAllEntries(){
    this.appservice.GetAllEntries()
      .subscribe(
        (successResponse) => {
          this.phoneBookEntries = successResponse
        },
        (errorResponse) => {
          console.log(errorResponse);
        }
      );
  }

  SaveNewPhonebookEntry() {
    this.appservice.SaveNewPhonebookEntry(this.selectedPhoneBookEntry)
      .subscribe(
        (successResponse) => {
          this.GetAllEntries();
          this.showTable = true;
          console.log(successResponse);

        },(errorResponse) => {
          console.log(errorResponse);
        })
  }
  
  UpdatePhonebookEntry(){
    this.appservice.UpdatePhonebookEntry(this.selectedPhoneBookEntry.phoneBookEntryId, this.selectedPhoneBookEntry)
      .subscribe(
        (successResponse) => {
          this.GetAllEntries();
          this.showTable = true;
        },
        (errorResponse) => {

        }
      )
  }

  RemovePhonebookEntry(phoneBookEntryId:number) {
    this.appservice.RemovePhonebookEntry(phoneBookEntryId)
      .subscribe(
        (successResponse) => {
          this.GetAllEntries();
        },
        (errorResponse) => {
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

}

