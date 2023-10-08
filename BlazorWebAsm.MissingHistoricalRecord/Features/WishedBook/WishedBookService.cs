using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.SupabaseModule;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.WishedBook
{
    public class WishedBookService
    {
        private readonly SupabaseService _supabase;

        public WishedBookService(SupabaseService supabase)
        {
            _supabase = supabase;
        }

        public async Task<bool> SaveWishBook(WishedBookDataModel model)
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

        public async Task<bool> RemoveBookmark(WishedBookDataModel data)
        {
            try
            {
                await _supabase.RemoveAsync<WishedBookDataModel>(x =>
                x.BookId == data.BookId &&
                x.BookCode == data.BookCode
                );
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> IsWishedBook(WishedBookDataModel model)
        {
            bool isWishedBook = false;
            try
            {
                var result = await _supabase
                    .CountAsync<WishedBookDataModel>
                    (x =>
                        x.BookId == model.BookId &&
                        x.BookCode == model.BookCode
                    );
                isWishedBook = result > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return isWishedBook;
        }

        public async Task<WishedBookListResponseModel> GetWishBookList(string userId = "")
        {
            WishedBookListResponseModel response = new();
            try
            {
                var dataList = await _supabase.GetAllAsync<WishedBookDataModel>(); // need to filter with userID
                List<WishedBookViewModel> wishBookList = new();

                foreach (var data in dataList)
                {
                    var wishBook = new WishedBookViewModel
                    {
                        WishBookId = data.WishBookId,
                        BookCode = data.BookCode,
                        BookId = data.BookId,
                        BookName = await GetBookName(data.BookId)
                    };
                    wishBookList.Add(wishBook);
                }

                response.WishedBookList = wishBookList;
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
