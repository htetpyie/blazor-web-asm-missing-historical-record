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
        BookListResponseModel bookList = new();
        var dataList = await _supabase
            .GetLatestListAsync<BookDataModel>(
                (x => x.IsDelete == false &&
                      x.Status == EnumBookStatus.Complete.ToString()),
                x => x.CreatedDate, //Order by created date
                Postgrest.Constants.Ordering.Descending,
                pageSize);
        bookList.BookList = dataList.Select(x => x.Change()).ToList();

        return bookList;
    }

    public async Task GetBookmarkList()
    {
            
    }
}