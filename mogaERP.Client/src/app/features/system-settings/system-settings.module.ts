import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SystemSettingsRoutingModule } from './system-settings-routing.module';
import { CustomersComponent } from './customers/customers.component';
import { ProvidersComponent } from './providers/providers.component';
import { ItemsComponent } from './stores-settings/items/items.component';
import { ItemsGroupComponent } from './stores-settings/items-group/items-group.component';
import { ItemsUnitsComponent } from './stores-settings/items-units/items-units.component';
import { MainGroupsComponent } from './stores-settings/main-groups/main-groups.component';
import { StoresComponent } from './stores-settings/stores/stores.component';
import { StoresTypesComponent } from './stores-settings/stores-types/stores-types.component';
import { BanksComponent } from './finance-settings/banks/banks.component';
import { FinTreeComponent } from './finance-settings/fin-tree/fin-tree.component';
import { AccountingGuideComponent } from './finance-settings/accounting-guide/accounting-guide.component';
import { CostCenterComponent } from './finance-settings/cost-center/cost-center.component';
import { FinYearComponent } from './finance-settings/fin-year/fin-year.component';
import { TreasuriesComponent } from './finance-settings/treasuries/treasuries.component';
import { SharedModule } from 'primeng/api';


@NgModule({
  declarations: [
    CustomersComponent,
    ProvidersComponent,
    ItemsComponent,
    ItemsGroupComponent,
    ItemsUnitsComponent,
    MainGroupsComponent,
    StoresComponent,
    StoresTypesComponent,
    BanksComponent,
    FinTreeComponent,
    AccountingGuideComponent,
    CostCenterComponent,
    FinYearComponent,
    TreasuriesComponent
  ],
  imports: [
    CommonModule,
    SystemSettingsRoutingModule,
    SharedModule
  ]
})
export class SystemSettingsModule { }
