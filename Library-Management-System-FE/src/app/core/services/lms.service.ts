import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResult, PagedResult, Author, AuthorParams } from '../models/lms.models';

@Injectable({
  providedIn: 'root'
})
export class LmsService {
  private apiUrl = 'https://localhost:7279/api'; // Based on your backend settings

  constructor(private http: HttpClient) { }

  private cleanParams(params: any): any {
    const clean: any = {};
    for (const key in params) {
      if (params[key] !== null && params[key] !== undefined) {
        clean[key] = params[key];
      }
    }
    return clean;
  }

  getAuthorsPaged(params: AuthorParams): Observable<ApiResult<PagedResult<Author>>> {
    return this.http.get<ApiResult<PagedResult<Author>>>(
      `${this.apiUrl}/authors/paged`, 
      { params: this.cleanParams(params) }
    );
  }
}

