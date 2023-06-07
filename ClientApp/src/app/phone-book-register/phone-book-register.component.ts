import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-phone-book-register',
  templateUrl: './phone-book-register.component.html',
  styleUrls: ['./phone-book-register.component.css']
})
export class PhoneBookRegisterComponent {

  firstName: string = "";
  surname: string = "";
  phoneNumber: string = "";

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {
  }
}

