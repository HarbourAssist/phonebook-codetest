import { Component, Input } from "@angular/core";
import { IPhoneBookEntry } from "../../models/phone-book-entry.interface";
import { PhoneBookService } from "../phone-book.service";

@Component({
  selector: 'app-phone-book-item',
  templateUrl: 'phone-book-item.component.html'
})
export class PhoneBookDetailComponent {

  constructor(private phoneBookService: PhoneBookService) { }

  isEditEnabled: boolean = false;
  @Input() phoneBookEntry!: IPhoneBookEntry

  toggleEdit() {
    this.isEditEnabled = !this.isEditEnabled;
    return;
  }

  delete() {
    this.phoneBookService.delete(this.phoneBookEntry.phoneBookEntryId)
      .toPromise()
      .then(() => this.phoneBookService.getAll());
  }

}
