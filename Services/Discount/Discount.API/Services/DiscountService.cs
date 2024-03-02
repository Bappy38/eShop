using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.API.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IMediator mediator;
    private readonly ILogger<DiscountService> logger;

    public DiscountService(IMediator mediator, ILogger<DiscountService> logger)
    {
        this.mediator = mediator;
        this.logger = logger;
    }

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var getDiscountQuery = new GetDiscountQuery(request.ProductName);
        var result = await mediator.Send(getDiscountQuery);
        logger.LogInformation($"Discount is retrieved for the product name: {result.ProductName}");
        return result;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var createDiscountCommand = new CreateDiscountCommand(
            request.Coupon.ProductName,
            request.Coupon.Description,
            request.Coupon.Amount
        );
        var result = await mediator.Send(createDiscountCommand);
        logger.LogInformation($"Discount is successfully created for the product name: {result.ProductName}");
        return result;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var updateDiscountCommand = new UpdateDiscountCommand(request.Coupon.Id, request.Coupon.ProductName, request.Coupon.Description, request.Coupon.Amount);
        var result = await mediator.Send(updateDiscountCommand);
        logger.LogInformation($"Discount is successfully updated for the product name: {result.ProductName}");
        return result;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var deleteDiscountCommand = new DeleteDiscountCommand(request.ProductName);
        var isDeleted = await mediator.Send(deleteDiscountCommand);
        var deletedResponse = new DeleteDiscountResponse
        {
            Success = isDeleted
        };
        return deletedResponse;
    }
}
