using BlazorWebAsm.MissingHistoricalRecord.Features.Book;

namespace BlazorWebAsm.MissingHistoricalRecord.Features
{
    public static class ChangeModel
    {
        public static BookResponseModel Change(this BookDataModel data)
        {
            if (data == null) return new();
            return new BookResponseModel
            {
                BookId = data.BookId,
                BookAuthor = data.BookAuthor,
                BookTitle = data.BookTitle,
                BookCover = data.BookCover,
                BookCode = data.BookCode,
                BookCategoryCode = data.BookCategoryCode,
                BookDescription = data.BookDescription,
                Status = data.Status
            };
        }
    }
}
