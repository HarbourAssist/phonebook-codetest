import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PhoneBookEntry } from './models/phone-book-entry';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhoneBookService {
  private phoneBookUrl = 'https://localhost:44425/phonebook/';
  
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  public getPhoneBookEntries(): Observable<PhoneBookEntry[]> {
    debugger;
    return this.http.get<PhoneBookEntry[]>(this.phoneBookUrl + 'list');
  }

  public addPhoneBookEntry(entry: PhoneBookEntry): Observable<PhoneBookEntry> {
    return this.http.post<PhoneBookEntry>(this.phoneBookUrl, entry);
  }

  public updatePhoneBookEntry(entry: PhoneBookEntry): Observable<any> {
    return this.http.put<any>(this.phoneBookUrl, entry);
  }

  public deletePhoneBookEntry(entryId: number): Observable<any> {
    return this.http.delete<any>(this.phoneBookUrl + entryId);
  }
}
