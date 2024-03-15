using AutoMapper;
using Discount.Application.Abstractions.Messaging;
using Discount.Application.Mappers;
using Discount.Domain.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;

namespace Discount.Application.Queries.Handlers;

public class GetDiscountQueryHandler : IQueryHandler<GetDiscountQuery, CouponModel>
{
    private readonly IDiscountRepository discountRepository;
    private readonly IMapper mapper;

    public GetDiscountQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
    {
        this.discountRepository = discountRepository;
        this.mapper = mapper;
    }
    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await discountRepository.GetDiscount(request.productName);
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with the product name = {request.productName} not found"));
        }

        var couponModel = mapper.Map<CouponModel>(coupon);
        return couponModel;
    }
}
