using BlazorWebAsm.MissingHistoricalRecord.Features.Book;
using BlazorWebAsm.MissingHistoricalRecord.Features.BookContent;
using BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark;
using BlazorWebAsm.MissingHistoricalRecord.Features.WishBook;

namespace BlazorWebAsm.MissingHistoricalRecord.Features
{
    public static class ChangeModel
    {
        public static BookViewModel Change(this BookDataModel data)
        {
            if (data == null) return new();
            return new BookViewModel
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
        
        public static BookmarkDataModel Change(this BookmarkViewModel model)
        {
            if (model == null) return null;
            return new BookmarkDataModel
            {
              BookId = model.BookId,
              BookCode =  model.BookCode,
              PageNo = model.PageNo,
              CreatedDate = DateTime.Now,
            };
        }
        
        public static BookContentViewModel Change(this BookContentDataModel data)
        {
            if (data == null) return null;
            return new BookContentViewModel
            {
                BookContentPageNo = data.BookContentPageNo,
                BookContentText = data.BookContentText
            };
        }
    }
}
