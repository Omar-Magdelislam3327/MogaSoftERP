import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemsUnitsComponent } from './items-units.component';

describe('ItemsUnitsComponent', () => {
  let component: ItemsUnitsComponent;
  let fixture: ComponentFixture<ItemsUnitsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItemsUnitsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItemsUnitsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
