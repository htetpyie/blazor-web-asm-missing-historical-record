namespace BlazorWebAsm.MissingHistoricalRecord.Features.WishBook
{
    public class WishBookState
    {
        private WishBookListResponseModel? wishBookListResponse;
        public WishBookListResponseModel? WishBookListResponse
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
