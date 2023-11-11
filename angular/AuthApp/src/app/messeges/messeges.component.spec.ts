import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessegesComponent } from './messeges.component';

describe('MessegesComponent', () => {
  let component: MessegesComponent;
  let fixture: ComponentFixture<MessegesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MessegesComponent]
    });
    fixture = TestBed.createComponent(MessegesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
