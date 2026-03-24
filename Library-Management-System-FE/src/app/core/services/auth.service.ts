import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ApiResult, UserLoginDto, UserRegisterDto, User, AuthResponse } from '../models/lms.models';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private apiUrl = `${environment.apiUrl}/users`;
  private currentUserSubject = new BehaviorSubject<User | null>(null);
  public currentUser$ = this.currentUserSubject.asObservable();

  constructor(private http: HttpClient) {
    const savedUser = localStorage.getItem('lms_user');
    if (savedUser && savedUser !== 'undefined') {
      try {
        this.currentUserSubject.next(JSON.parse(savedUser));
      } catch (err) {
        console.error('Failed to parse user from storage', err);
        localStorage.removeItem('lms_user');
        localStorage.removeItem('lms_token');
      }
    }
  }


  public get currentUserValue(): User | null {
    return this.currentUserSubject.value;
  }

  login(credentials: UserLoginDto): Observable<ApiResult<AuthResponse>> {
    return this.http.post<ApiResult<AuthResponse>>(`${this.apiUrl}/login`, credentials).pipe(
      map(response => {
        if (response.isSuccess && response.data) {
          this.saveAuthData(response.data);
        }
        return response;
      })
    );
  }

  register(details: UserRegisterDto): Observable<ApiResult<any>> {
    return this.http.post<ApiResult<any>>(`${this.apiUrl}/register`, details);
  }

  logout(): void {
    localStorage.removeItem('lms_token');
    localStorage.removeItem('lms_user');
    this.currentUserSubject.next(null);
  }

  private saveAuthData(auth: AuthResponse): void {
    if (auth.token && auth.user) {
      localStorage.setItem('lms_token', auth.token);
      localStorage.setItem('lms_user', JSON.stringify(auth.user));
      this.currentUserSubject.next(auth.user);
    }
  }


  getToken(): string | null {
    return localStorage.getItem('lms_token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}
