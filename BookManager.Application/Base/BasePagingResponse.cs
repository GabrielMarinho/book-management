namespace BookManager.Application.Base;

public abstract class BasePagingResponse<T> : CommandResponse where T: class
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<T> Items { get; set; }
}