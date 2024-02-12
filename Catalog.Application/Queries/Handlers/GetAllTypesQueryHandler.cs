using Catalog.Application.Abstractions.Messaging;
using Catalog.Application.Mappers;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Queries.Handlers;

public sealed class GetAllTypesQueryHandler : IQueryHandler<GetAllTypesQuery, IList<TypeResponse>>
{
    private readonly ITypeRepository typeRepository;

    public GetAllTypesQueryHandler(ITypeRepository typeRepository)
    {
        this.typeRepository = typeRepository;
    }
    public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        var types = await typeRepository.GetAllTypes();
        var typesResponse = ProductMapper.Mapper.Map<IList<TypeResponse>>(types);
        return typesResponse;
    }
}
