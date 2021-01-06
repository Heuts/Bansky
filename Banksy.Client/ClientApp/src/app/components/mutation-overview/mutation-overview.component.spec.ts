import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { MutationOverviewComponent } from './mutation-overview.component';

describe('MutationOverviewComponent', () => {
  let component: MutationOverviewComponent;
  let fixture: ComponentFixture<MutationOverviewComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ MutationOverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MutationOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
