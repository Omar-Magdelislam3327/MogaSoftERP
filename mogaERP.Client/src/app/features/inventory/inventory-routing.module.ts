import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReciptPermissionsComponent } from './recipt-permissions/recipt-permissions.component';

const routes: Routes = [
  {
    path: 'recipt-permissions',
    component: ReciptPermissionsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryRoutingModule { }
