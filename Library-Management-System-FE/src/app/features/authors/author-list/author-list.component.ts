import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LmsService } from '../../../core/services/lms.service';
import { Author, AuthorParams } from '../../../core/models/lms.models';

@Component({
  selector: 'app-author-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './author-list.component.html',
  styleUrl: './author-list.component.css'
})
export class AuthorListComponent implements OnInit {
  authors: Author[] = [];
  totalCount = 0;
  loading = true;

  currentPage = 1;
  pageSize = 10;
  totalPages = 0;
  pages: number[] = [];

  constructor(private lmsService: LmsService) { }

  ngOnInit(): void {
    this.loadAuthors();
  }

  loadAuthors(): void {
    this.loading = true;
    const params: AuthorParams = {
      pageNumber: this.currentPage,
      pageSize: this.pageSize,
      sortOrder: 1,
      sortField: 'fullName',
      search: null,
      isActive: null
    };

    this.lmsService.getAuthorsPaged(params).subscribe({
      next: (response) => {
        if (response.isSuccess) {
          this.authors = response.data.result;
          this.totalCount = response.data.totalCount;
          this.calculatePages();
        }
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading authors:', err);
        this.loading = false;
      }
    });
  }

  calculatePages(): void {
    this.totalPages = Math.ceil(this.totalCount / this.pageSize);
    this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages && page !== this.currentPage) {
      this.currentPage = page;
      this.loadAuthors();
    }
  }
}
