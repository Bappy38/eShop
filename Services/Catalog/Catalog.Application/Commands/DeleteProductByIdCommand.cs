using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Commands;

public sealed record DeleteProductByIdCommand(string Id) : ICommand<bool>;
