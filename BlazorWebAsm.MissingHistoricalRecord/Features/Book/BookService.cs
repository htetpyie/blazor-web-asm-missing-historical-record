using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;
using BlazorWebAsm.MissingHistoricalRecord.Shared.Enums;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.Book
{
    public class BookService
    {
        private readonly SupabaseService _supabase;

        public BookService(SupabaseService supabase)
        {
            _supabase = supabase;
        }

        public async Task<BookListResponseModel> GetBookList(int pageNo = 1, int pageSize = 4)
        {
            BookListResponseModel bookList = new();
            try
            {
                var dataList = await _supabase
                    .GetListByPaginationAsync<BookDataModel>(
                        (x => x.IsDelete == false &&
                              x.Status == EnumBookStatus.Complete.ToString()
                        ),
                        pageNo,
                        pageSize);

                bookList.BookList = dataList
                    .Select(x => x.Change())
                    .ToList();

                bookList.BookCount = await _supabase
                    .CountAsync<BookDataModel>(
                        x =>
                            x.IsDelete == false &&
                            x.Status == EnumBookStatus.Complete.ToString()
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bookList;
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
}