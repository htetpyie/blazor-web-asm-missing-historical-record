namespace BlazorWebAsm.MissingHistoricalRecord.Features.Bookmark
{
    public class BookmarkState
    {
        private BookmarkListResponseModel? bookMarkList;

        public BookmarkListResponseModel? BookMarkList
        {
            get => bookMarkList;
            set
            {
                bookMarkList = value;
                BookmarkStateHasChanged();
            }
        }

        public event EventHandler OnChange;

        private void BookmarkStateHasChanged() => OnChange?.Invoke(this,EventArgs.Empty);
    }
}
