import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WeaponsStatComponent } from './weapons-stat.component';

describe('WeaponsStatComponent', () => {
  let component: WeaponsStatComponent;
  let fixture: ComponentFixture<WeaponsStatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WeaponsStatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WeaponsStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
