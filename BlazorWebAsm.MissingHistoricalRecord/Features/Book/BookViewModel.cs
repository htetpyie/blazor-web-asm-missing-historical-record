namespace BlazorWebAsm.MissingHistoricalRecord.Features.Book;

public class BookViewModel
{
    public Guid BookId { get; set; }
    public string? BookCode { get; set; }
    public string? BookTitle { get; set; }
    public string? BookDescription { get; set; }
    public string? BookCategoryCode { get; set; }
    public string? BookCover { get; set; }
    public string? BookAuthor { get; set; }
    public string? Status { get; set; }
}

public class SearchBookViewModel{
    public Guid BookId { get; set; }
    public string BookCode { get; set; }
    public string? BookTitle { get; set; }
}