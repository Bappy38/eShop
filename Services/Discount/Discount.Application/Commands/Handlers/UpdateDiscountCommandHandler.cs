using Discount.Application.Abstractions.Messaging;
using Discount.Application.Mappers;
using Discount.Domain.Entities;
using Discount.Domain.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;

namespace Discount.Application.Commands.Handlers;

public class UpdateDiscountCommandHandler : ICommandHandler<UpdateDiscountCommand, CouponModel>
{
    private readonly IDiscountRepository discountRepository;

    public UpdateDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        this.discountRepository = discountRepository;
    }
    public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.Mapper.Map<Coupon>(request);
        var isSucceed = await discountRepository.UpdateDiscount(coupon);

        if (!isSucceed)
        {
            throw new RpcException(new Status(StatusCode.Internal, $"Failed to update discount with product name {request.productName}"));
        }

        var couponModel = DiscountMapper.Mapper.Map<CouponModel>(coupon);    
        return couponModel;
    }
}
