using Postgrest.Attributes;
using Postgrest.Models;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.WishBook
{

    [Table("Tbl_wishbook")]
    public class WishBookDataModel : BaseModel
    {
        [PrimaryKey("wishbook_id")]
        public Guid WishBookId { get; set; }
        [Column("book_id")]
        public Guid BookId { get; set; }
        [Column("book_code")]
        public string BookCode { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
    }
}
