import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AuthorListComponent } from './author-list.component';
import { LmsService } from '../../../core/services/lms.service';
import { of } from 'rxjs';
import { FormsModule } from '@angular/forms';

describe('AuthorListComponent', () => {
  let component: AuthorListComponent;
  let fixture: ComponentFixture<AuthorListComponent>;
  let lmsServiceSpy: jasmine.SpyObj<LmsService>;

  beforeEach(async () => {
    const spy = jasmine.createSpyObj('LmsService', ['getAuthorsPaged']);

    await TestBed.configureTestingModule({
      imports: [AuthorListComponent, FormsModule],
      providers: [
        { provide: LmsService, useValue: spy }
      ]
    })
    .compileComponents();

    lmsServiceSpy = TestBed.inject(LmsService) as jasmine.SpyObj<LmsService>;
    lmsServiceSpy.getAuthorsPaged.and.returnValue(of({ 
      isSuccess: true, 
      code: 200, 
      data: [], 
      totalCount: 0, 
      totalPages: 0, 
      pageNumber: 1, 
      pageSize: 10 
    }));

    fixture = TestBed.createComponent(AuthorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should load authors on init', () => {
    expect(lmsServiceSpy.getAuthorsPaged).toHaveBeenCalled();
  });

  it('should reset page number on search', () => {
    component.currentPage = 3;
    component.onSearch();
    expect(component.currentPage).toBe(1);
    expect(lmsServiceSpy.getAuthorsPaged).toHaveBeenCalled();
  });

  it('should navigate to valid page', () => {
    component.totalPages = 5;
    component.currentPage = 1;
    component.goToPage(2);
    expect(component.currentPage).toBe(2);
    expect(lmsServiceSpy.getAuthorsPaged).toHaveBeenCalledTimes(2);
  });
});


