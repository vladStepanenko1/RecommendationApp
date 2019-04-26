import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommendedPlayersComponent } from './recommended-players.component';

describe('RecommendedPlayersComponent', () => {
  let component: RecommendedPlayersComponent;
  let fixture: ComponentFixture<RecommendedPlayersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecommendedPlayersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommendedPlayersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
