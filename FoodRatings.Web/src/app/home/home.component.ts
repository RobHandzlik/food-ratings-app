import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import * as _ from 'lodash';
import { Authority } from '../models/authority';
import { AuthorityResult } from '../models/authority-result';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  loading = true;
  hasResults = false;
  errorMessage: string;
  
  authorities: Authority[];
  selectedAuthotityId = 0;
  authorityResults: AuthorityResult[];
  
  constructor(
    private readonly dataService: DataService) { }

  ngOnInit() {
    this.dataService.getAuthorities()
      .subscribe(
        a => {
          this.authorities = a;
          this.loading = false;
        },
        error => this.errorMessage = 'Failed to get authorities'
      );
  }

  onSelect() {
    this.loading = true;
    this.hasResults = false;
    this.dataService.getEstablishmentsResultsForAuthoriyId(this.selectedAuthotityId)
      .subscribe(
        r  => {
          this.authorityResults = r;
          this.loading = false;
          this.hasResults = true;;
        },
        error => this.errorMessage = 'Failed to get results for authority'
      );
  } 
}
