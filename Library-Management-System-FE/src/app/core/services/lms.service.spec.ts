import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { LmsService } from './lms.service';
import { environment } from '../../../environments/environment';
import { AuthorParams, BookParams } from '../models/lms.models';

describe('LmsService', () => {
  let service: LmsService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [LmsService]
    });
    service = TestBed.inject(LmsService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch authors paged', () => {
    const mockParams: AuthorParams = { pageNumber: 1, pageSize: 10 };
    const mockResponse = { isSuccess: true, code: 200, data: [{ id: 1, fullName: 'Author 1' }], totalCount: 1 };


    service.getAuthorsPaged(mockParams).subscribe(response => {
      expect(response.isSuccess).toBeTrue();
      expect(response.data.length).toBe(1);
      expect(response.data[0].fullName).toBe('Author 1');
    });

    const req = httpMock.expectOne(req => 
      req.url === `${environment.apiUrl}/authors/paged` && 
      req.params.get('pageNumber') === '1'
    );
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });

  it('should fetch books paged', () => {
    const mockParams: BookParams = { pageNumber: 1, pageSize: 12, search: 'test' };
    const mockResponse = { isSuccess: true, code: 200, data: [{ id: 1, title: 'Book 1' }], totalCount: 1 };


    service.getBooksPaged(mockParams).subscribe(response => {
      expect(response.isSuccess).toBeTrue();
      expect(response.data[0].title).toBe('Book 1');
    });

    const req = httpMock.expectOne(req => 
      req.url === `${environment.apiUrl}/books/paged` && 
      req.params.get('Search') === 'test'
    );
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });
});

