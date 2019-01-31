using AuctionManagement.Gateways.RestApi;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionManagement.Config
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddAuction(this IMvcBuilder builder)
        {
            builder.AddApplicationPart(typeof(AuctionsController).Assembly);
            return builder;
        }
    }
}