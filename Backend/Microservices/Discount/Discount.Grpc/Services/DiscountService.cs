using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Discount.Grpc.Services
{
    public class DiscountService(ILogger<DiscountService> logger, DiscountContext dbContext) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));

            dbContext.Coupons.Add(coupon);
            await dbContext.SaveChangesAsync(context.CancellationToken);

            logger.LogInformation($"Discount is Created for productName: ({coupon.ProductName})");

            var couponModel = coupon.Adapt<CouponModel>();

            return couponModel;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext
                .Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName, context.CancellationToken);

            if (coupon == null)
                coupon = new Coupon() { ProductName = "No Discount", Amount = 0, Description = "No Discount" };

            logger.LogInformation($"Discount is retrieved for productName: ({coupon.ProductName})");

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

            dbContext.Coupons.Update(coupon);
            await dbContext.SaveChangesAsync(context.CancellationToken);

            logger.LogInformation($"Discount is Updated for productName: ({coupon.ProductName})");

            var couponModel = coupon.Adapt<CouponModel>();

            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext
                .Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName, context.CancellationToken);

            if (coupon == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName: ({request.ProductName}) not found."));

            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync(context.CancellationToken);

            logger.LogInformation($"Discount is Deleted for productName: ({coupon.ProductName})");

            return new DeleteDiscountResponse { Success = true};
        }
    }
}
