import { Component } from '@angular/core';
import { PhoneBookService } from '../phone-book.service';
import { PhoneBookEntry } from '../models/phone-book-entry';

@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css']
})
export class PhoneBookComponent {
  phoneBookEntriesList: PhoneBookEntry[] = [];
  selectedEntry?: PhoneBookEntry;

  constructor(
    private phoneBookService: PhoneBookService
  ) {
  }

  ngOnInit(): void {
    this.phoneBookService
      .getPhoneBookEntries()
      .subscribe((data: PhoneBookEntry[]) => 
      {
        debugger;
        this.phoneBookEntriesList = data;
      });    
  }

  
  editSelected(phoneBookEntryEdited: PhoneBookEntry): void {
    this.selectedEntry = phoneBookEntryEdited;
    this.phoneBookService
      .updatePhoneBookEntry(phoneBookEntryEdited)
      .subscribe((data: any) => 
      {
        debugger;
        this.phoneBookEntriesList = data;
        this.selectedEntry = undefined;
      });   
  }

  deleteSelected(id?: number): void {
    if(id){
      this.phoneBookService
      .deletePhoneBookEntry(id)
      .subscribe((data: any) => 
      {
        debugger;
        this.phoneBookEntriesList = data;
        this.selectedEntry = undefined;
      });
    }    
  }
}

