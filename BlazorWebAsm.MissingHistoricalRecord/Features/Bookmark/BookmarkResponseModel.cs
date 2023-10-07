namespace BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark;

public class BookmarkResponseModel
{
    public string BookTitle { get; set; }
    public Guid BookId { get; set; }
    public List<BookmarkViewModel> BookmarkList { get; set; }
}
