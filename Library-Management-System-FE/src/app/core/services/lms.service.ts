import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResult, Author, AuthorParams,BookParams,Book } from '../models/lms.models';

@Injectable({
  providedIn: 'root'
})
export class LmsService {
  private apiUrl = 'https://library-management-api-h3en.onrender.com/api'; // Live Render backend

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

  getAuthorsPaged(params: AuthorParams): Observable<ApiResult<Author[]>> {
    return this.http.get<ApiResult<Author[]>>(
      `${this.apiUrl}/authors/paged`, 
      { params: this.cleanParams(params) }
    );
  }

  getBooksPaged(params: BookParams): Observable<ApiResult<Book[]>> {

    return this.http.get<ApiResult<Book[]>>(
      `${this.apiUrl}/books/paged`, 
      {params:this.cleanParams(params)}
    );
  }
}