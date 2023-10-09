import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { PhoneBookService } from '../phone-book.service';
import { PhoneBookEntry } from '../models/phone-book-entry';

@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css']
})
export class PhoneBookComponent implements OnInit{
  phoneBookEntriesList: PhoneBookEntry[] = [];
  selectedEntry?: PhoneBookEntry;
  ModalTitle = "";
  showAddOrEditPhoneBookEntryComponent: boolean = false;
  @ViewChild('modalClose') modalCloseBtn?: ElementRef;

  constructor(
    private phoneBookService: PhoneBookService
  ) {
  }

  ngOnInit(): void {
     this.loadPhoneBookEntriesList();   
  }

  loadPhoneBookEntriesList(){
    this.phoneBookService
      .getPhoneBookEntries()
      .subscribe((data: PhoneBookEntry[]) => 
      {
        this.phoneBookEntriesList = data;
      });
  }

  addPhoneBookEntryClick(): void {
    this.ModalTitle = "Add phone book entry";
    this.showAddOrEditPhoneBookEntryComponent = true;
  }
  
  editPhoneBookEntryClick(phoneBookEntryEdited: PhoneBookEntry): void {
    this.selectedEntry = phoneBookEntryEdited;
    this.ModalTitle = "Edit phone book entry";
    this.showAddOrEditPhoneBookEntryComponent = true;
  }

  deleteSelected(id?: number): void {
    if (confirm('Are you sure you want to delete the entry?') && id) {
      this.phoneBookService
      .deletePhoneBookEntry(id)
      .subscribe(() => 
      {
        this.loadPhoneBookEntriesList();
      });
    }
  }
  
  closePhoneBookEntryClick(): void {
    this.showAddOrEditPhoneBookEntryComponent = false;
    this.loadPhoneBookEntriesList();
  }

  phoneBookRecordAddedOrUpdated(): void{
    alert("Phone book entry has been saved.");
    this.modalCloseBtn?.nativeElement.click();
    this.loadPhoneBookEntriesList();
  }
}

