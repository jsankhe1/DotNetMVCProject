namespace Core.Helpers;

public class PagedResultSet<T> where T:class
{
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int PageNumber => (int)Math.Ceiling((double)TotalCount / PageSize);
    public IEnumerable<T> Items { get; set; }




}