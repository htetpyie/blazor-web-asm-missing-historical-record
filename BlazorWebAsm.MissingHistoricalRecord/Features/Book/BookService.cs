using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.Book
{
    public class BookService
    {
        private readonly SupabaseService _supabase;

        public BookService(SupabaseService supabase)
        {
            _supabase = supabase;
        }

        public async Task<BookViewModel> GetBookData(BookDataModel book)
        {
            BookViewModel model = new();
            try
            {
                var data = await _supabase
                    .GetAsync<BookDataModel>(x => 
                    x.BookId == book.BookId && 
                    x.BookCode == book.BookCode);

                model = data.Change();
            }
            catch (Exception ex)
            {
                throw;
            }

            return model;
        }
    }
}