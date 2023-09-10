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

    public async Task<bool> SaveBookmark(BookmarkViewModel model)
    {
        try
        {
            var data = await _supabase.InsertAsync<>(model.Change());
            return data != null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> RemoveBookmark(string bookmarkId)
    {
        try
        {
            Guid id = new Guid(bookmarkId);
            await _supabase
                .RemoveAsync<BookmarkDataModel>(
                    x => x.BookMarkId == id);
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

        List<BookmarkDataModel> bookmarkDataList = await _supabase
            .GetAllAsync<BookmarkDataModel>();

        response.BookmarkList = bookmarkDataList
            .Select(x => new BookmarkViewModel()
            {
                BookId = x.BookId,
                BookCode = x.BookCode,
                BookName = GetBookName(x.BookId).Result
            })
            .ToList();

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