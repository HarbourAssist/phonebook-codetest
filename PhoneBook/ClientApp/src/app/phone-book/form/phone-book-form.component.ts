import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IPhoneBookEntry } from "../../models/phone-book-entry.interface";
import { PhoneBookEntry } from "../../models/phone-book-entry.model";
import { PhoneBookService } from "../phone-book.service";


@Component({
  selector: 'app-phone-book-form',
  templateUrl: './phone-book-form.component.html',
})
export class PhoneBookFormComponent implements OnInit {

  @Input() phoneBookEntry!: IPhoneBookEntry;

  @Input() isFormEnabled!: boolean;
  @Output() isFormEnabledChange: EventEmitter<boolean> = new EventEmitter<boolean>();

  phoneEntryForm: FormGroup = new FormGroup({
    firstName: new FormControl('', Validators.required),
    surname: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
  });

  constructor(private phoneBookService: PhoneBookService) { }

  ngOnInit(): void {

    if (this.phoneBookEntry?.phoneBookEntryId == null)
      return;

    this.phoneEntryForm = new FormGroup({
        phoneBookEntryId: new FormControl(this.phoneBookEntry.phoneBookEntryId, Validators.required),
        firstName: new FormControl(this.phoneBookEntry.firstname, Validators.required),
        surname: new FormControl(this.phoneBookEntry.surname, Validators.required),
        phoneNumber: new FormControl(this.phoneBookEntry.phoneNumber, Validators.required),
      });
    }


  onSubmit() {

    if (this.phoneBookEntry != null) {
      this.update();
      return;
    }

    this.createNew();
  }

  private createNew(): void {

    let phoneBookEntry = new PhoneBookEntry(this.phoneEntryForm.value);
    this.phoneBookService.create(phoneBookEntry)
      .toPromise()
      .then(() => {
        this.phoneBookService.getAll();
        this.isFormEnabled = !this.isFormEnabled;
        this.isFormEnabledChange.emit(this.isFormEnabled);
      });
  }

  private update(): void {

    let phoneBookEntry = new PhoneBookEntry(this.phoneEntryForm.value);
    this.phoneBookService.update(this.phoneBookEntry.phoneBookEntryId, phoneBookEntry)
      .toPromise()
      .then(() => this.phoneBookService.getAll());

  }

}
