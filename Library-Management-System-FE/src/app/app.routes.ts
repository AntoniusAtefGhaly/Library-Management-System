import { Routes } from '@angular/router';
import { BookListComponent } from './features/books/book-list/book-list.component';
import { AuthorListComponent } from './features/authors/author-list/author-list.component';
import { LoginComponent } from './features/auth/login/login.component';
import { RegisterComponent } from './features/auth/register/register.component';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'books', component: BookListComponent },
  { path: 'authors', component: AuthorListComponent }
];

