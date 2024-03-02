using Discount.Application.Abstractions.Messaging;
using Discount.Application.Mappers;
using Discount.Domain.Entities;
using Discount.Domain.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;

namespace Discount.Application.Commands.Handlers;

public class CreateDiscountCommandHandler : ICommandHandler<CreateDiscountCommand, CouponModel>
{
    private readonly IDiscountRepository discountRepository;

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        this.discountRepository = discountRepository;
    }
    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.Mapper.Map<Coupon>(request);
        var isSucceed = await discountRepository.CreateDiscount(coupon);

        if (!isSucceed)
        {
            throw new RpcException(new Status(StatusCode.Internal, $"Failed to create discount for product name {request.productName}"));
        }

        var couponModel = DiscountMapper.Mapper.Map<CouponModel>(coupon);
        return couponModel;
    }
}
