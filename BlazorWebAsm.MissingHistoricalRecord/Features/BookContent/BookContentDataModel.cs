using Postgrest.Attributes;
using Postgrest.Models;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.BookContent;

[Table("Tbl_book_content")]
public class BookContentDataModel : BaseModel
{
    [PrimaryKey("book_content_id")]
    public Guid BookContentId { get; set; }
    [Column("book_code")]
    public string BookCode { get; set; }
    [Column("book_content_page_no")]
    public int BookContentPageNo { get; set; }
    [Column("book_content")]
    public string BookContentText { get; set; }
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    [Column("created_by")]
    public int CreatedBy { get; set; }
    [Column("modified_date")]
    public DateTime ModifiedDate { get; set; }
    [Column("modified_by")]
    public int ModifiedBy { get; set; }
    [Column("is_delete")]
    public bool IsDelete { get; set; }
}