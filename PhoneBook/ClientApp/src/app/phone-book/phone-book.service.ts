import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { IPhoneBookEntry } from "../models/phone-book-entry.interface";
import { PhoneBookEntry } from "../models/phone-book-entry.model";

@Injectable()
export class PhoneBookService {

  private _apiUrl: string = "/api/phonebook";

  private _phoneBookEntries: BehaviorSubject<IPhoneBookEntry[]> = new BehaviorSubject<IPhoneBookEntry[]>([]);
  public phoneBookEntries$: Observable<IPhoneBookEntry[]> = this._phoneBookEntries.asObservable();

  constructor(private http: HttpClient) {

  }

  getAll(): Promise<any> {
    this.http.get<IPhoneBookEntry[]>(this._apiUrl).subscribe(phoneBookEntries => this._phoneBookEntries.next(phoneBookEntries));
    return Promise.resolve();
  }

  create(phoneBookEntry: PhoneBookEntry): Observable<any> {
    return this.http.post(this._apiUrl, phoneBookEntry);
  }

  update(id: number, phoneBookEntry: PhoneBookEntry): Observable<any> {
    return this.http.patch(this._apiUrl + `/${id}`, phoneBookEntry);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this._apiUrl + `/${id}`);
  }

}
