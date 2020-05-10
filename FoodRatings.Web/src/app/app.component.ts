import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit, ViewContainerRef  } from '@angular/core';

import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  values: string[];
  username: string;
  accessDenied = false;
  loading = true;

  constructor(private toastr: ToastsManager,
    private vcr: ViewContainerRef, private oAuthService: OAuthService) {
    this.toastr.setRootViewContainerRef(vcr);    
  }

  ngOnInit(): void {
    this.loading = false;
  }
}
