namespace BlazorWebAsm.MissingHistoricalRecord.Features.Book
{
    public class BookListResponseModel
    {
        public List<BookViewModel> LatestBookList { get; set; }
        public int TotalBookCount { get; set; }
    }
}
