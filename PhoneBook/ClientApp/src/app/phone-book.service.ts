import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PhoneBookEntry } from './models/phone-book-entry';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhoneBookService {
  private phoneBookUrl = 'http://localhost:5000/api/phonebook';
  
  constructor(
    private http: HttpClient,
    // @Inject('BASE_URL') private baseUrl: string
  ) { }

  addPhoneBookEntry(entry: PhoneBookEntry): number {
return 1;
  }

  getPhoneBookEntries(): Observable<PhoneBookEntry[]> {
    return this.http.get<PhoneBookEntry[]>(this.phoneBookUrl + '/list');
  }
}
