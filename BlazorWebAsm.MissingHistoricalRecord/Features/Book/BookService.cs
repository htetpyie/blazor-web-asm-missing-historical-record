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
       
    }
}