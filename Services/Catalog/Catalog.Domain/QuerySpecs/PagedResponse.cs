namespace Catalog.Domain.QuerySpecs;

public class PagedResponse<T> where T : class
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public long Count { get; set; }
    public IReadOnlyList<T> Data { get; set; }

    public PagedResponse() {}

    public PagedResponse(int pageIndex, int pageSize, long count, IReadOnlyList<T> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }
}
