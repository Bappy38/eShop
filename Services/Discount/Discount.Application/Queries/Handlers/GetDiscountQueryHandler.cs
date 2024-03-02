using Discount.Application.Abstractions.Messaging;
using Discount.Application.Mappers;
using Discount.Domain.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;

namespace Discount.Application.Queries.Handlers;

public class GetDiscountQueryHandler : IQueryHandler<GetDiscountQuery, CouponModel>
{
    private readonly IDiscountRepository discountRepository;

    public GetDiscountQueryHandler(IDiscountRepository discountRepository)
    {
        this.discountRepository = discountRepository;
    }
    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = discountRepository.GetDiscount(request.productName);
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with the product name = {request.productName} not found"));
        }

        var couponModel = DiscountMapper.Mapper.Map<CouponModel>(coupon);
        return couponModel;
    }
}
