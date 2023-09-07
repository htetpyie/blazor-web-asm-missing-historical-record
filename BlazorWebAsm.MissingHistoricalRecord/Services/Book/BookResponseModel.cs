namespace BlazorWebAsm.MissingHistoricalRecord.Services.Book
{
    public class BookResponseModel
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

    public class BookListResponseModel
    {
        public List<BookResponseModel> BookList { get; set; }
        public int BookCount { get; set; }
    }
}
