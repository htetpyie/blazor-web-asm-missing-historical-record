namespace BlazorWebAsm.MissingHistoricalRecord.Features.WishedBook
{
    public class WishedBookViewModel
    {
        public Guid WishBookId { get; set; }
        public Guid BookId{ get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
    }

    public class WishedBookListResponseModel
    {
        public List<WishedBookViewModel> WishedBookList { get; set; }
    }
}
