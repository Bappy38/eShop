namespace Catalog.Domain.QuerySpecs;

public class ProductQueryParams
{
    private const int MaxPageSize = 50;

    private int _pageSize;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize)? MaxPageSize : value;
    }
    public int PageIndex { get; set; } = 1;
    public string? BrandId { get; set; }
    public string? TypeId { get; set; }
    public string? SortKey { get; set; }
    public bool IsAscending { get; set; } = true;
    public string? Search { get; set; }

    public int Skip()
    {
        return (PageIndex - 1) * PageSize;
    }
}
