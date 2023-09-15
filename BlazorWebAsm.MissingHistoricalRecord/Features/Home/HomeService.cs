using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;
using BlazorWebAsm.MissingHistoricalRecord.Features.Enums;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.Home;

public class HomeService
{
    private readonly SupabaseService _supabase;

    public HomeService(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public async Task<BookListResponseModel> GetLatestBookList(int pageSize = 4)
    {
        string bookStatus = EnumBookStatus.Complete.ToString();
        BookListResponseModel bookList = new();
        var dataList = await _supabase
            .GetLatestListAsync<BookDataModel>(
                (x => x.IsDelete == false &&
                      x.Status == bookStatus),
                x => x.CreatedDate, //Order by created date
                Postgrest.Constants.Ordering.Descending,
                pageSize);

        bookList.LatestBookList = dataList.Select(x => x.Change()).ToList();
        bookList.TotalBookCount = await GetBookTotalCount();

        return bookList;
    }

    public async Task<IEnumerable<SearchBookViewModel>> GetAllBook()
    {
        string status = EnumBookStatus.Complete.ToString();
        var dataList = await _supabase.GetAllAsync<BookDataModel>(
            x => new object[] { x.BookId, x.BookCode, x.BookTitle },
            x => x.IsDelete == false &&
                 x.Status == status);
        var resultList = dataList
            .Select(x =>
                new SearchBookViewModel()
                {
                    BookId = x.BookId,
                    BookCode = x.BookCode,
                    BookTitle = x.BookTitle
                });
        return resultList;
    }

    public async Task GetBookmarkList()
    {
    }

    private async Task<int> GetBookTotalCount()
    {
        var list = await GetAllBook();
        return list.Count();
    }
}