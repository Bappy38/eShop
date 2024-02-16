using Catalog.Application.Abstractions.Messaging;
using Catalog.Application.Mappers;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Queries.Handlers;

public sealed class GetAllBrandsQueryHandler : IQueryHandler<GetAllBrandsQuery, IList<BrandReponse>>
{
    private readonly IBrandRepository brandRepository;

    public GetAllBrandsQueryHandler(IBrandRepository brandRepository)
    {
        this.brandRepository = brandRepository;
    }

    public async Task<IList<BrandReponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllBrands();
        var brandsReponse = ProductMapper.Mapper.Map<IList<ProductBrand>, IList<BrandReponse>>(brands.ToList());
        return brandsReponse;
    }
}
