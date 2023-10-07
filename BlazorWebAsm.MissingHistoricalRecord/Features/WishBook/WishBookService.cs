using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.WishBook
{
    public class WishBookService
    {
        private readonly SupabaseService _supabase;

        public WishBookService(SupabaseService supabase)
        {
            _supabase = supabase;
        }

        public async Task<bool> SaveWishBook(WishBookDataModel model)
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

        public async Task<bool> RemoveBookmark(WishBookDataModel data)
        {
            try
            {
                await _supabase.RemoveAsync<WishBookDataModel>(x => x.WishBookId == data.WishBookId);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<WishBookListResponseModel> GetWishBookList(string userId = "")
        {
            WishBookListResponseModel response = new();
            try
            {
                var dataList = await _supabase.GetAllAsync<WishBookDataModel>(); // need to filter with userID
                List<WishBookViewModel> wishBookList = new();

                foreach(var data in dataList)
                {
                    var wishBook = new WishBookViewModel
                    {
                        WishBookId = data.WishBookId,
                        BookCode = data.BookCode,
                        BookId = data.BookId,
                        BookName = await GetBookName(data.BookId)
                    };
                    wishBookList.Add(wishBook);
                }

                response.WishBookList = wishBookList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }

        private async Task<string> GetBookName(Guid bookId)
        {
            string bookName = string.Empty;
            try
            {
                var book = await _supabase.GetAsync<BookDataModel>(
                        x => x.BookId == bookId);
                if (book is not null) bookName = book.BookTitle;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bookName;
        }
    }
}
