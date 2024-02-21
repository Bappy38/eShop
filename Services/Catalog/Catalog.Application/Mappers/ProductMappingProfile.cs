using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Domain.Entities;
using Catalog.Domain.QuerySpecs;

namespace Catalog.Application.Mappers;

public class ProductMappingProfile : Profile
{
	public ProductMappingProfile()
	{
		CreateMap<ProductBrand, BrandReponse>().ReverseMap();
        CreateMap<ProductType, TypeResponse>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, ProductResponse>().ReverseMap();
		CreateMap<PagedResponse<Product>, PagedResponse<ProductResponse>>().ReverseMap();
	}
}
