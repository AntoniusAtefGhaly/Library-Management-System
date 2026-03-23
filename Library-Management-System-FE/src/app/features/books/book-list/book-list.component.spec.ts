import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { BookListComponent } from './book-list.component';
import { LmsService } from '../../../core/services/lms.service';
import { of } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { ImageUrlPipe } from '../../../core/pipes/image-url.pipe';

describe('BookListComponent', () => {
  let component: BookListComponent;
  let fixture: ComponentFixture<BookListComponent>;
  let lmsServiceSpy: jasmine.SpyObj<LmsService>;

  beforeEach(async () => {
    const spy = jasmine.createSpyObj('LmsService', ['getBooksPaged']);

    await TestBed.configureTestingModule({
      imports: [BookListComponent, FormsModule, ImageUrlPipe],
      providers: [
        { provide: LmsService, useValue: spy }
      ]
    })
    .compileComponents();

    lmsServiceSpy = TestBed.inject(LmsService) as jasmine.SpyObj<LmsService>;
    lmsServiceSpy.getBooksPaged.and.returnValue(of({ isSuccess: true, code: 200, data: [], totalCount: 0, totalPages: 0, pageNumber: 1, pageSize: 10 }));


    fixture = TestBed.createComponent(BookListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should load books on init', () => {
    expect(lmsServiceSpy.getBooksPaged).toHaveBeenCalled();
  });

  it('should reset page number on search', () => {
    component.pageNumber = 5;
    component.searchTerm = 'test';
    component.onSearch();
    expect(component.pageNumber).toBe(1);
    expect(lmsServiceSpy.getBooksPaged).toHaveBeenCalled();
  });

  it('should navigate to valid page', () => {
    component.totalPages = 10;
    component.pageNumber = 1;
    component.goToPage(3);
    expect(component.pageNumber).toBe(3);
    expect(lmsServiceSpy.getBooksPaged).toHaveBeenCalledTimes(2); // One for init, one for goToPage
  });

  it('should not navigate to invalid page', () => {
    component.totalPages = 5;
    component.pageNumber = 2;
    component.goToPage(10);
    expect(component.pageNumber).toBe(2);
  });
});

