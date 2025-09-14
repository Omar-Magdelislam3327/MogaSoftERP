import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { AccountingGuideComponent } from './finance-settings/accounting-guide/accounting-guide.component';
import { BanksComponent } from './finance-settings/banks/banks.component';
import { CostCenterComponent } from './finance-settings/cost-center/cost-center.component';
import { FinTreeComponent } from './finance-settings/fin-tree/fin-tree.component';
import { FinYearComponent } from './finance-settings/fin-year/fin-year.component';
import { TreasuriesComponent } from './finance-settings/treasuries/treasuries.component';
import { ProvidersComponent } from './providers/providers.component';
import { ItemsComponent } from './stores-settings/items/items.component';
import { MainGroupsComponent } from './stores-settings/main-groups/main-groups.component';
import { StoresTypesComponent } from './stores-settings/stores-types/stores-types.component';
import { StoresComponent } from './stores-settings/stores/stores.component';
import { ItemsGroupComponent } from './stores-settings/items-group/items-group.component';
import { ItemsUnitsComponent } from './stores-settings/items-units/items-units.component';

const routes: Routes = [
  { path:"customers", component:CustomersComponent},
  { path:"providers", component:ProvidersComponent},
  // Stores settings
  { path:"stores-settings/main-groups", component:MainGroupsComponent},
  { path:"stores-settings/items-groups", component:ItemsGroupComponent},
  { path:"stores-settings/item-units", component:ItemsUnitsComponent},
  { path:"stores-settings/items", component:ItemsComponent},
  { path:"stores-settings/stores", component:StoresComponent},
  { path:"stores-settings/stores-types", component:StoresTypesComponent},
  // Financial settings
  { path:"finance-settings/financial-tree", component:FinTreeComponent},
  { path:"finance-settings/accounting-guide", component:AccountingGuideComponent},
  { path:"finance-settings/treasuries", component:TreasuriesComponent},
  { path:"finance-settings/banks", component:BanksComponent},
  { path:"finance-settings/financial-year", component:FinYearComponent},
  { path:"finance-settings/cost-center", component:CostCenterComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SystemSettingsRoutingModule { }
