import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InventoryRoutingModule } from './inventory-routing.module';
import { ReciptPermissionsComponent } from './recipt-permissions/recipt-permissions.component';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [
    ReciptPermissionsComponent
  ],
  imports: [
    CommonModule,
    InventoryRoutingModule,
    SharedModule
  ]
})
export class InventoryModule { }
