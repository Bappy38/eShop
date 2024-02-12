using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Queries;

public class GetProductByBrandQuery : IQuery<IList<ProductResponse>>
{
    public string BrandName { get; set; }

	public GetProductByBrandQuery(string brandName)
	{
		BrandName = brandName;
	}
}
