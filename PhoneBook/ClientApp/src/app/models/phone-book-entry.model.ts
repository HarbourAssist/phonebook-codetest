export class PhoneBookEntry {
  public constructor(phoneBook?: Partial<PhoneBookEntry>) {
    Object.assign(this, phoneBook);
  }
}
