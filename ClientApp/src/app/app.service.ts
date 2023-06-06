import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; // used to make api calls
import { Observable } from 'rxjs';
import { PhoneBookEntry } from './models/phone-book-entry';
import { PhonebookEntryRequest } from './models/phonebookEntryRequest';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  private baseApiUrl = 'https://localhost:44425'

  constructor(private httpClient: HttpClient) { }
  
  GetAllEntries(): Observable<any> {
    return this.httpClient.get<any>(this.baseApiUrl + '/phonebook/GetAllEntries');
  }


  SaveNewPhonebookEntry(phoneRequest: PhoneBookEntry): Observable<string> {
    const phonebookEntryRequest: PhonebookEntryRequest = {
      phoneBookEntryId: phoneRequest.phoneBookEntryId,
      firstname: phoneRequest.firstname,
      surname: phoneRequest.surname,
      phoneNumber: phoneRequest.phoneNumber,
    }
    return this.httpClient.post(this.baseApiUrl + '/phonebook/SaveNewPhonebookEntry', phonebookEntryRequest, {responseType: 'text'});
  }

  UpdatePhonebookEntry(phoneBookEntryId: number, phoneRequest: PhoneBookEntry): Observable<PhoneBookEntry> {
    const phonebookEntryRequest: PhonebookEntryRequest = {
      phoneBookEntryId: phoneRequest.phoneBookEntryId,
      firstname: phoneRequest.firstname,
      surname: phoneRequest.surname,
      phoneNumber: phoneRequest.phoneNumber,
    }
    return this.httpClient.put<PhoneBookEntry>(this.baseApiUrl + '/phonebook/UpdatePhonebookEntry/' + phoneBookEntryId, phonebookEntryRequest);
  }

  RemovePhonebookEntry(phoneBookEntryId: number): Observable<PhoneBookEntry> {
    return this.httpClient.delete<PhoneBookEntry>(this.baseApiUrl + '/phonebook/RemovePhonebookEntry/' + phoneBookEntryId);
  }
}
