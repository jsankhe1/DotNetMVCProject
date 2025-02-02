namespace Core.Helpers;

public class PagedResultSet<T> where T : class
{
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; } // Store the current page number
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize); // Fix calculation
    public IEnumerable<T> Items { get; set; }
}