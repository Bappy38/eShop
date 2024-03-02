using Discount.Application.Abstractions.Messaging;
using Discount.Grpc.Protos;

namespace Discount.Application.Queries;

public sealed record GetDiscountQuery(string productName) : IQuery<CouponModel>;
