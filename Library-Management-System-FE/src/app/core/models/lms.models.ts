export interface ApiResult<T> {
  message?: string;
  isSuccess: boolean;
  code: number;
  data: T;
}

export interface PagedResult<T> {
  result: T[];
  totalCount: number;
}

export interface AuthorParams {
  pageNumber?: number;
  pageSize?: number;
  sortOrder?: number;
  sortField?: string | null;
  search?: string | null;
  isActive?: boolean | null;
}

export interface Book {
  id: number;
  title: string;
  authorName: string;
  imageUrl?: string;
  availableCopies: number;
}

export interface Author {
  id: number;
  fullName: string;
  bookCount: number;
  description?: string;
  dateOfBirth?: string;
  isActive: boolean;
  imageURL?: string;
}
