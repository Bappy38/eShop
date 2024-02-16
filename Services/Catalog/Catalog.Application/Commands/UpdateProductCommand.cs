using Catalog.Application.Abstractions.Messaging;
using Catalog.Domain.Entities;

namespace Catalog.Application.Commands;

public sealed record UpdateProductCommand(
    string Id, 
    string Name,
    string Summary,
    string Description,
    string ImageFile,
    ProductBrand Brand,
    ProductType Type,
    decimal Price) : ICommand<bool>;