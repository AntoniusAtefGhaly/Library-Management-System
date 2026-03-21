import { Routes } from '@angular/router';
import { BookListComponent } from './features/books/book-list/book-list.component';
import { AuthorListComponent } from './features/authors/author-list/author-list.component';

export const routes: Routes = [
  { path: '', redirectTo: 'books', pathMatch: 'full' },
  { path: 'books', component: BookListComponent },
  { path: 'authors', component: AuthorListComponent }
];
