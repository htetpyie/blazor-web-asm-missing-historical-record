using Postgrest.Attributes;
using Postgrest.Models;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.Book
{
    [Table("Tbl_book")]
    public class BookDataModel : BaseModel
    {
        [PrimaryKey("book_id")]
        public Guid BookId { get; set; }
        [Column("book_code")]
        public string? BookCode { get; set; }
        [Column("book_title")]
        public string? BookTitle { get; set; }
        [Column("book_desp")]
        public string? BookDescription { get; set; }
        [Column("book_category_code")]
        public string? BookCategoryCode { get; set; }
        [Column("book_cover")]
        public string? BookCover { get; set; }
        [Column("book_author")]
        public string? BookAuthor { get; set; }
        [Column("status")]
        public string? Status { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("created_by")]
        public int? CreatedBy { get; set; }
        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
        [Column("modified_by")]
        public int? ModifiedBy { get; set; }
        [Column("is_delete")]
        public bool? IsDelete { get; set; }
    }
}
