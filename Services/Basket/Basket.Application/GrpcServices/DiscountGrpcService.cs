using Discount.Grpc.Protos;

namespace Basket.Application.GrpcServices;

public class DiscountGrpcService
{
    private readonly DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient;

    public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
    {
        this.discountProtoServiceClient = discountProtoServiceClient;
    }

    public async Task<CouponModel> GetDiscount(string productName)
    {
        var discountRequest = new GetDiscountRequest
        {
            ProductName = productName
        };

        return await discountProtoServiceClient.GetDiscountAsync(discountRequest);
    }
}
