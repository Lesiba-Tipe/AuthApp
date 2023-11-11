import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotAuthaurizedComponent } from './not-authaurized.component';

describe('NotAuthaurizedComponent', () => {
  let component: NotAuthaurizedComponent;
  let fixture: ComponentFixture<NotAuthaurizedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NotAuthaurizedComponent]
    });
    fixture = TestBed.createComponent(NotAuthaurizedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
