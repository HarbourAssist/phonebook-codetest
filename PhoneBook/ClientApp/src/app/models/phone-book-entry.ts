export class PhoneBookEntry {
  public phoneBookEntryId?: number;
  public firstName: string;
  public surname: string;
  public phoneNumber: string;

  constructor(firstName: string, surname: string, phoneNumber: string){
    this.firstName = firstName;
    this.surname = surname;
    this.phoneNumber = phoneNumber;
  }
}
