using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark;

public class BookmarkService
{
    private readonly SupabaseService _supabase;

    public BookmarkService(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public async Task<bool> SaveBookmark(BookmarkDataModel model)
    {
        try
        {
            var data = await _supabase.InsertAsync(model);
            return data != null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> RemoveBookmark(BookmarkDataModel data)
    {
        try
        {
            await _supabase
                .RemoveAsync<BookmarkDataModel>(
                    x =>
                        x.BookCode == data.BookCode &&
                        x.PageNo == data.PageNo);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<BookmarkListResponseModel> GetBookmarkList(string userId = "") //User id is for future plan
    {
        BookmarkListResponseModel response = new();

        try
        {
            List<BookmarkDataModel> bookmarkDataList = await _supabase
                .GetAllAsync<BookmarkDataModel>();

            var bookmarkList = bookmarkDataList
                .Select(x => new BookmarkViewModel()
                {
                    BookId = x.BookId,
                    BookCode = x.BookCode,
                    PageNo = x.PageNo
                })
                .ToList();

            var bookmarkResponse = bookmarkList
                .GroupBy(x => x.BookId)
                .Select(item =>
                    new BookmarkResponseModel
                    {
                        BookId = item.Key,
                        BookmarkList = item.ToList(),
                    })
                .ToList();

            foreach (var item in bookmarkResponse)
            {
                item.BookTitle = await GetBookName(item.BookId);
            }

            response.BookmarkResponseList = bookmarkResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return response;
    }

    private async Task<string> GetBookName(Guid bookId)
    {
        string bookName = string.Empty;
        var data = await _supabase
            .GetAsync<BookDataModel>(book => book.BookId == bookId);
        if (data is not null)
        {
            bookName = data.BookTitle;
        }

        return bookName;
    }
}