import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LmsService } from '../../../core/services/lms.service';
import { Book } from '../../../core/models/lms.models';
import { BookParams } from '../../../core/models/lms.models';
import { ImageUrlPipe } from '../../../core/pipes/image-url.pipe';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, ImageUrlPipe, FormsModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  pageNumber = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;
  pages: number[] = [];

  // Used for two-way binding with the HTML input
  searchTerm: string = '';

  constructor(private lmservice: LmsService) { }
  ngOnInit(): void {
    this.loadBooks();
  }
  loadBooks(): void {
    var params: BookParams = {
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
      sortOrder: 1,
      sortField: 'title',
      search: this.searchTerm || null,
      authorId: null
    };

    this.lmservice.getBooksPaged(params)
      .subscribe((response: any) => {
        // Map the properties if they exist
        this.books = response.data || [];
        this.totalCount = response.totalCount || 0;
        this.totalPages = response.totalPages || 0;
        this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1);
      });
  }

  onSearch(): void {
    this.pageNumber = 1; // Essential: Always jump back to page 1 on a fresh search!
    this.loadBooks();
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages && page !== this.pageNumber) {
      this.pageNumber = page;
      this.loadBooks();
    }
  }
}


