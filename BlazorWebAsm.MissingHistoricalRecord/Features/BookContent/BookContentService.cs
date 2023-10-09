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

    public async Task<BookContentResponseModel?> GetBookPageContents(
        string bookId, int pageNo = 0)
    {
        BookContentResponseModel response = new();
        try
        {
            var isValid = Guid.TryParse(bookId, out Guid bookIdAsGuid);
            if (!isValid) return null;

            var book = await _supabase
                .GetAsync<BookDataModel>(x =>
                    x.BookId == bookIdAsGuid &&
                    x.IsDelete == false);

            //For book id validation
            if (book is null) return null;

            var contentData = await GetBookContentData(book.BookCode, pageNo);
            var bookContents = contentData
                .Select(x => x.Change())
                .ToList();
            response.IsBookMark = await IsBookMark(contentData);
            response.BookContents = bookContents;
            response.ContentCount = await GetBookContentCount(book.BookCode);
            response.LeftPageNo = bookContents.Count > 0
                ? bookContents
                    .Min(x => x.BookContentPageNo)
                : 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return response;
    }

    private async Task<List<BookContentDataModel>> GetBookContentData(
        string bookCode, int pageNo)
    {
        // Cause of index start 0 
        int from = 0;
        if (pageNo > 0)
        {
            from = (pageNo % 2 == 0)
                ? pageNo - 2
                : pageNo - 1;
        }
        int to = from + 1;
        
        var bookContentData = await _supabase
            .GetListWithLimitAsync<BookContentDataModel>(x =>
                    x.BookCode == bookCode &&
                    x.IsDelete == false,
                from, to);

        return bookContentData;
    }

    private async Task<int> GetBookContentCount(string bookCode)
    {
        var contentCount = await _supabase
            .CountAsync<BookContentDataModel>(x =>
                x.BookCode == bookCode &&
                x.IsDelete == false);
        return contentCount;
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