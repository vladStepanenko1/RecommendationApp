import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MapsStatComponent } from './maps-stat.component';

describe('MapsStatComponent', () => {
  let component: MapsStatComponent;
  let fixture: ComponentFixture<MapsStatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MapsStatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MapsStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
