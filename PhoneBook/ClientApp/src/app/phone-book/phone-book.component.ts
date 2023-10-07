import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { PhoneBookService } from '../phone-book.service';
import { PhoneBookEntry } from '../models/phone-book-entry';

@Component({
  selector: 'app-phone-book',
  templateUrl: './phone-book.component.html',
  styleUrls: ['./phone-book.component.css']
})
export class PhoneBookComponent {
  phoneBookEntryForm = this.fb.group({
    firstName: ['', Validators.required],
    surname: ['', Validators.required],
    phoneNumber: ['', Validators.required],
  });

  get firstName() { return this.phoneBookEntryForm.get('firstName'); }
  get surname() { return this.phoneBookEntryForm.get('surname'); }
  get phoneNumber() { return this.phoneBookEntryForm.get('phoneNumber'); }

  constructor(
    private phoneBookService: PhoneBookService,
    private fb: FormBuilder
  ) {
  }

  createPhoneBookEntry() {
    let newPhoneBookEntry = new PhoneBookEntry(
      this.phoneBookEntryForm.value.firstName ?? '',
      this.phoneBookEntryForm.value.surname ?? '',
      this.phoneBookEntryForm.value.phoneNumber ?? '');
    
    this.phoneBookService.addPhoneBookEntry(newPhoneBookEntry);
  }
}

