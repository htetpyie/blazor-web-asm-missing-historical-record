using BlazorWebAsm.MissingHistoricalRecord.Features.Book;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.BookShelf;

public class BookShelfResponseModel
{
    public List<BookViewModel> BookList { get; set; }
    public int BookCount { get; set; }
    
    public int TotalPage { get; set; }
}