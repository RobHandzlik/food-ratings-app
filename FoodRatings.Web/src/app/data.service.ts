import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Authority } from './models/authority';
import { AuthorityResult } from './models/authority-result';

@Injectable()
export class DataService {
  constructor(
    private readonly httpClient: HttpClient,
  ) { }

  getAuthorities(): Observable<Authority[]> {
    return this.httpClient
      .get<Authority[]>('api/v0/authorities');
  }

  getEstablishmentsResultsForAuthoriyId(authorityId: number): Observable<AuthorityResult[]> {
    return this.httpClient
      .get<AuthorityResult[]>(`api/v0/authorities/${authorityId}/results`);
  }
}
