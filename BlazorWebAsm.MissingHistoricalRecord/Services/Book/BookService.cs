using BlazorWebAsm.MissingHistoricalRecord.Services.SupabaseModule;

namespace BlazorWebAsm.MissingHistoricalRecord.Services.Book
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
                (x => x.IsDelete == false),
                pageNo,
                pageSize);
                bookList.BookList = dataList.Select(x => x.Change()).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return bookList;
        }
    }
}
