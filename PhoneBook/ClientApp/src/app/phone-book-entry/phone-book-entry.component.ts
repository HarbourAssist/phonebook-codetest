import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder } from '@angular/forms';
import { PhoneBookService } from '../phone-book.service';
import { PhoneBookEntry } from '../models/phone-book-entry';

@Component({
  selector: 'app-phone-book-entry',
  templateUrl: './phone-book-entry.component.html',
  styleUrls: ['./phone-book-entry.component.css']
})
export class PhoneBookEntryComponent {
  @Input() phoneBookEntry?: PhoneBookEntry;

  phoneBookEntryForm = this.fb.group({
    firstName: [this.phoneBookEntry?.firstName ?? '', Validators.required],
    surname: [this.phoneBookEntry?.surname ??'', Validators.required],
    phoneNumber: [this.phoneBookEntry?.phoneNumber ??'', Validators.required],
  });

  get firstName() { return this.phoneBookEntryForm.get('firstName'); }
  get surname() { return this.phoneBookEntryForm.get('surname'); }
  get phoneNumber() { return this.phoneBookEntryForm.get('phoneNumber'); }

  constructor(
    private phoneBookService: PhoneBookService,
    private fb: FormBuilder,
    private router: Router
  ) {
  }

  createPhoneBookEntry() {
    let newPhoneBookEntry = new PhoneBookEntry(
      this.phoneBookEntryForm.value.firstName ?? '',
      this.phoneBookEntryForm.value.surname ?? '',
      this.phoneBookEntryForm.value.phoneNumber ?? '');
    
    this.phoneBookService.addPhoneBookEntry(newPhoneBookEntry)
    .subscribe(data => {
      this.router.navigate(['/phone-book']);
    }
    );
  }
}
