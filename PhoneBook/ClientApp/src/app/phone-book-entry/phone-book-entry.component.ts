import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { PhoneBookService } from '../phone-book.service';
import { PhoneBookEntry } from '../models/phone-book-entry';

@Component({
  selector: 'app-phone-book-entry',
  templateUrl: './phone-book-entry.component.html',
  styleUrls: ['./phone-book-entry.component.css']
})
export class PhoneBookEntryComponent implements OnInit {
  @Input() phoneBookEntry?: PhoneBookEntry;
  @Output() phoneBookUpdatedEvent = new EventEmitter();

  phoneBookEntryForm: FormGroup = this.fb.group({
    firstName: ['', Validators.required],
    surname: ['', Validators.required],
    phoneNumber: ['', Validators.required],
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

  ngOnInit(): void {
    this.phoneBookEntryForm.controls.firstName.setValue(this.phoneBookEntry?.firstName);
    this.phoneBookEntryForm.controls.surname.setValue(this.phoneBookEntry?.surname);
    this.phoneBookEntryForm.controls.phoneNumber.setValue(this.phoneBookEntry?.phoneNumber);
  }

  addOrUpdateEntry(): void {
    let phoneBookEntryToSave = new PhoneBookEntry(
      this.phoneBookEntryForm.value.firstName,
      this.phoneBookEntryForm.value.surname,
      this.phoneBookEntryForm.value.phoneNumber);

    if(this.phoneBookEntry?.phoneBookEntryId && this.phoneBookEntry?.phoneBookEntryId != 0){
      phoneBookEntryToSave.phoneBookEntryId = this.phoneBookEntry?.phoneBookEntryId;
      this.phoneBookService
      .updatePhoneBookEntry(phoneBookEntryToSave)
      .subscribe(() => 
      {
        this.phoneBookUpdatedEvent.emit();
      });   
    }
    else{
      this.phoneBookService.addPhoneBookEntry(phoneBookEntryToSave)
      .subscribe(() => {
        this.phoneBookUpdatedEvent.emit();
      }
      );
    }
  }
}
