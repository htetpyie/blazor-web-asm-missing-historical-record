using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark;
using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.BookContent;

public class BookContentService
{
    private readonly SupabaseService _supabase;

    public BookContentService(SupabaseService supabase)
    {
        _supabase = supabase;
    }
    
    public async Task<BookPageResponseModel> GetBookPageContents(string bookCode,int pageNo = 2)
    {
        BookPageResponseModel response = new();
        try
        {
            var contentCount = await _supabase
                .CountAsync<BookContentDataModel>(x =>
                    x.BookCode == bookCode &&
                    x.IsDelete == false);
            var bookContentData = await _supabase
                .GetAllAsync<BookContentDataModel>(x =>
                    x.BookCode == bookCode &&
                    x.IsDelete == false);
            var isBookMark = await IsBookMark(bookContentData);
            var bookContents = bookContentData
                .Select(x => x.Change())
                .ToList();
            var book = await _supabase
                .GetAsync<BookDataModel>(x =>
                    x.BookCode == bookCode &&
                    x.IsDelete == false);
            string bookName = (book != null) ? book.BookTitle : "Unknown";
            
            response.ContentCount = contentCount;
            response.IsBookMark = isBookMark;
            response.BookContents = bookContents;
            response.BookName = bookName;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
            
        return response;
    }

    private async Task<bool> IsBookMark(List<BookContentDataModel> list)
    {
        foreach (var item in list)
        {
            var result = await _supabase
                .GetAsync<BookmarkDataModel>(x => 
                    x.BookCode == item.BookCode &&
                    x.PageNo == item.BookContentPageNo);
            if (result is not null) return true;
        }

        return false;
    }
}