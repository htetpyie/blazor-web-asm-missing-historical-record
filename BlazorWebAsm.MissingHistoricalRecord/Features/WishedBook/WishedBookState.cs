namespace BlazorWebAsm.MissingHistoricalRecord.Features.WishedBook
{
    public class WishedBookState
    {
        private WishedBookListResponseModel? wishBookListResponse;
        public WishedBookListResponseModel? WishBookListResponse
        {
            get => wishBookListResponse;
            set
            {
                wishBookListResponse = value;
                WishBookListHasChanged();
            }
        }

        public event EventHandler? OnChange;

        public void WishBookListHasChanged() => OnChange?.Invoke(this, EventArgs.Empty);
    }
}
