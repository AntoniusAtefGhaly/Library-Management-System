export interface ApiResult<T> {
  message?: string;
  isSuccess: boolean;
  code: number;
  data: T;
  // Pagination fields sometimes included at the root
  totalCount?: number;
  pageNumber?: number;
  pageSize?: number;
  totalPages?: number;
}

export interface ApiPagedResult<T> {
  message?: string;
  isSuccess: boolean;
  code: number;
  data: T[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
}

export interface AuthorParams {
  pageNumber?: number;
  pageSize?: number;
  sortOrder?: number;
  sortField?: string | null;
  search?: string | null;
  isActive?: boolean | null;
}

export interface BookParams {
  pageNumber?: number;
  pageSize?: number;
  sortOrder?: number;
  sortField?: string | null;
  search?: string | null;
  authorId?: number | null;
}

export interface Book {
  id: number;
  title: string;
  description?: string;
  authorId: number;
  authorFullName: string;
  authorImage?: string;
  categoryId: number;
  categoryName: string;
  publicationYear: number;
  availableCopies: number;
  totalCopies: number;
  coverImageUrl?: string;
  isTrending: boolean;
  hasAvailableCopies: boolean;
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

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber?: string;
  roles?: string[];
}

export interface UserLoginDto {
  email: string;
  password: string;
}

export interface UserRegisterDto {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  phoneNumber: string;
}

export interface AuthResponse {
  token: string;
  user: User;
}

