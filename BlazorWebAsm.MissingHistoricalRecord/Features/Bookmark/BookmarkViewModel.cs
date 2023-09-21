namespace BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark;

public class BookmarkViewModel
{
    public Guid BookMarkId { get; set; }
    public Guid BookId { get; set; }
    public string BookCode { get; set; }
    public int PageNo { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }
}

public class BookmarkResponseModel
{
    public string BookTitle { get; set; }
    public Guid BookId { get; set; }
    public List<BookmarkViewModel> BookmarkList { get; set; }
}

public class BookmarkListResponseModel
{
    public List<BookmarkResponseModel> BookmarkResponseList { get; set; }
    public int Count
    {
        get => BookmarkResponseList.Count;
    }
}