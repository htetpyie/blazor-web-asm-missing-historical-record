﻿using MudBlazor;

namespace BlazorWebAsm.MissingHistoricalRecord.Features.BookContent;

public class BookPageResponseModel
{
    public List<BookContentViewModel> BookContents { get; set; }
    public string BookName { get; set; }
    public bool IsBookMark { get; set; }
    public int ContentCount { get; set; }
}