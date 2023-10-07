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
