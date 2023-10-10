import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneBookEntryComponent } from './phone-book-entry.component';

describe('PhoneBookEntryComponent', () => {
  let component: PhoneBookEntryComponent;
  let fixture: ComponentFixture<PhoneBookEntryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhoneBookEntryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhoneBookEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
