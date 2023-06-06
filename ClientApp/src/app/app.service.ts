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
  
  getData() {
    let url = "https://localhost:44425/api/PhoneBook/GetAllEntries"
  }
  GetAllEntries(): Observable<any> {
    return this.httpClient.get<any>(this.baseApiUrl + '/PhoneBook/GetAllEntries');
  }


  SaveNewPhonebookEntry(phoneRequest: PhoneBookEntry): Observable<PhoneBookEntry> {
    const phonebookEntryRequest: PhonebookEntryRequest = {
      phoneBookEntryId: phoneRequest.phoneBookEntryId,
      firstname: phoneRequest.firstname,
      surname: phoneRequest.surname,
      phoneNumber: phoneRequest.phoneNumber,
    }
    return this.httpClient.post<PhoneBookEntry>(this.baseApiUrl + '/PhoneBook/SaveNewPhonebookEntry', phonebookEntryRequest);
  }

  UpdatePhonebookEntry(phoneBookEntryId: number, phoneRequest: PhoneBookEntry): Observable<PhoneBookEntry> {
    const phonebookEntryRequest: PhonebookEntryRequest = {
      phoneBookEntryId: phoneRequest.phoneBookEntryId,
      firstname: phoneRequest.firstname,
      surname: phoneRequest.surname,
      phoneNumber: phoneRequest.phoneNumber,
    }
    return this.httpClient.put<PhoneBookEntry>(this.baseApiUrl + '/PhoneBook/UpdatePhonebookEntry/' + phoneBookEntryId, phonebookEntryRequest);
  }

  RemovePhonebookEntry(phoneBookEntryId: number): Observable<PhoneBookEntry> {
    return this.httpClient.delete<PhoneBookEntry>(this.baseApiUrl + '/PhoneBook/RemovePhonebookEntry/' + phoneBookEntryId);
  }
}
