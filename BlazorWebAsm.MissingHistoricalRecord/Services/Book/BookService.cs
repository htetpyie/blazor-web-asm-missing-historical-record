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

        public Task GetBook(Guid bookId)
        {
        }
    }
}
