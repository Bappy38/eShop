using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappers;

public class ProductMappingProfile : Profile
{
	public ProductMappingProfile()
	{
		CreateMap<ProductBrand, BrandReponse>().ReverseMap();
		CreateMap<Product, ProductResponse>().ReverseMap();
		CreateMap<Product, CreateProductCommand>().ReverseMap();
		CreateMap<ProductType, TypeResponse>().ReverseMap();
	}
}
