namespace BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark;

public class BookmarkListResponseModel
{
    public List<BookmarkResponseModel> BookmarkResponseList { get; set; }
    public int Count
    {
        get => BookmarkResponseList.Count;
    }
}