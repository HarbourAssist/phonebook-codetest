import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PhoneBookEntry } from './models/phone-book-entry';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhoneBookService {
  private phoneBookUrl = 'https://localhost:44425/phonebook';
  
  constructor(
    private http: HttpClient,
    // @Inject('BASE_URL') private baseUrl: string
  ) { }

  addPhoneBookEntry(entry: PhoneBookEntry): Observable<PhoneBookEntry> {
    debugger;
    return this.http.post<PhoneBookEntry>(this.phoneBookUrl, entry);
  }

  getPhoneBookEntries(): Observable<PhoneBookEntry[]> {
    return this.http.get<PhoneBookEntry[]>(this.phoneBookUrl + '/list');
  }
}
