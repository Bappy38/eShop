using Order.Application.Abstractions.Messaging;
using Order.Domain.Repositories;

namespace Order.Application.Commands;

public sealed record DeleteOrderCommand(int Id) : ICommand;