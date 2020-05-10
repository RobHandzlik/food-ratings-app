// Angular
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';

// App - Common
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from './routing/routing.module';
import { HomeComponent } from './home/home.component';

// App - Specific
import { DataService } from './data.service';

// Third Party
import { ToastModule } from 'ng2-toastr/ng2-toastr';
import { OAuthModule } from 'angular-oauth2-oidc';
import { LoadingModule, ANIMATION_TYPES } from 'ngx-loading';
import { ChartModule } from 'angular-highcharts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    OAuthModule.forRoot(),
    ToastModule.forRoot(),
    BsDropdownModule.forRoot(),
    LoadingModule.forRoot({
      fullScreenBackdrop: true,
      animationType: ANIMATION_TYPES.circle,
      primaryColour: '#e56c0c',
      backdropBorderRadius: '4px'
    }),
    HttpModule,
    ChartModule,
  ],
  providers: [DataService, HttpClient, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
