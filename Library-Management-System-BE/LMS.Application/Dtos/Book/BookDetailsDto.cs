namespace LMS.Application.Dtos.Book
{
    public class BookDetailsDto
    {
        // book Details
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public int PublicationYear { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
        // Author Details
        public string AuthorFullName { get; set; } = null!;
        public string AuthorDescription { get; set; } = null!;
        public DateOnly AuthorDateOfBirth { get; set; }
        public string? AuthorImageUrl { get; set; }

        // Category Details
        public string CategoryName { get; set; } = null!;
        public string CategoryDescription { get; set; } = null!;
        public string? CategoryImageUrl { get; set; }

        public bool IsBorrowed { get; set; }
        public bool HasAvailableCopies { get; set; }


    }
}
