namespace BlazorWebAsm.MissingHistoricalRecord.Features.WishBook
{
    public class WishBookViewModel
    {
        public Guid WishBookId { get; set; }
        public Guid BookId{ get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
    }

    public class WishBookListResponseModel
    {
        public List<WishBookViewModel> WishBookList { get; set; }
    }
}
