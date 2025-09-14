import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoaderComponent } from './core/interceptors/loader/loader.component';
import { DateFormatPipe } from './core/pipes/date-format.pipe';
import { LayoutComponent } from './shared/layout/layout.component';
import { LoginComponent } from './auth/login/login.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ChartModule } from 'angular-highcharts';
import { loadingInterceptor } from './core/interceptors/loading.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    LoaderComponent,
    DateFormatPipe,
    LayoutComponent,
    LoginComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ChartModule
  ],
  providers: [
    provideHttpClient(withInterceptors([loadingInterceptor]))
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
