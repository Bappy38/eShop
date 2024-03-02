using Discount.Application.Abstractions.Messaging;
using Discount.Grpc.Protos;

namespace Discount.Application.Commands;

public sealed record CreateDiscountCommand(string productName, string description, int amount) : ICommand<CouponModel>;
