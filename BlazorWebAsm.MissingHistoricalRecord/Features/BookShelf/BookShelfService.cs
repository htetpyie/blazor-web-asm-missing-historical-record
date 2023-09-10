using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;
using BlazorWebAsm.MissingHistoricalRecord.Shared.Enums;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.BookShelf;

public class BookShelfService
{
    private readonly SupabaseService _supabase;

    public BookShelfService(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public async Task<BookShelfResponseModel> GetBookShelf(
        int pageNo = 1, int pageSize = 8)
    {
        BookShelfResponseModel response = new();
        try
        {
            string status = EnumBookStatus.Complete.ToString();
            var dataList = await _supabase
                .GetListByPaginationAsync<BookDataModel>(
                    (x => x.IsDelete == false &&
                          x.Status == status
                    ),
                    pageNo,
                    pageSize);

            var bookList = dataList
                .Select(x => x.Change())
                .ToList();

            int bookCount = await _supabase
                .CountAsync<BookDataModel>(
                    x =>
                        x.IsDelete == false &&
                        x.Status == status
                );

            int totalPage = bookCount / pageSize;
            if (bookCount % pageSize > 0)
            {
                totalPage++;
            }

            response.BookList = bookList;
            response.BookCount = bookCount;
            response.TotalPage = totalPage;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

        return response;
    }
}