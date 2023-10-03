import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IPhoneBookEntry } from '../../models/phone-book-entry.interface';
import { PhoneBookService } from '../phone-book.service';

@Component({
  selector: 'app-phone-book-list',
  templateUrl: './phone-book-list.component.html',
  styleUrls: ['./phone-book-list.component.css']
})
export class PhoneBookComponent implements OnInit, OnDestroy {

  PhoneBookEntries: IPhoneBookEntry[] = [];
  isAddEnabled: boolean = false;
  private _subscriptions: Subscription[] = [];

  constructor(
    private phoneBookService: PhoneBookService
  ) {

  }
    

  ngOnInit(): void {

    this.phoneBookService.getAll().then(() => {
      let phoneBookEntrySub = this.phoneBookService.phoneBookEntries$.subscribe((phoneBookEntries: IPhoneBookEntry[]) => {

        this.PhoneBookEntries = phoneBookEntries;
      });

      this._subscriptions.push(phoneBookEntrySub);
    })
  }

  ngOnDestroy(): void {
    this._subscriptions.forEach(subscription => subscription.unsubscribe());
  }

  toggleAdd(): void {
    this.isAddEnabled = !this.isAddEnabled;
  }
}

