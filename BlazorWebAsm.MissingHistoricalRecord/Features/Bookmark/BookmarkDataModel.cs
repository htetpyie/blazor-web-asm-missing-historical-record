using Postgrest.Attributes;
using Postgrest.Models;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark;

[Table("Tbl_bookmark")]
public class BookmarkDataModel:BaseModel
{
    [PrimaryKey("bookmark_id")]
    public Guid BookMarkId { get; set; }
    [Column("book_id")]
    public Guid BookId { get; set; }
    [Column("book_code")]
    public string BookCode { get; set; }
    [Column("page_no")]
    public int PageNo { get; set; }
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    [Column("created_by")]
    public int CreatedBy { get; set; }
}