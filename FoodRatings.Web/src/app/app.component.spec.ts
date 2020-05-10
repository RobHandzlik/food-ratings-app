// Angular
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
import { TestBed, async } from '@angular/core/testing';
import { APP_BASE_HREF } from '@angular/common';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
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
      providers: [
        DataService,
        HttpClient,
        HttpClient,
        { provide: APP_BASE_HREF, useValue: '/' },
      ],

    }).compileComponents();
  }));

  it('should create the app', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));

  it('should render title in a h1 tag', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Create Client');
  }));
});
