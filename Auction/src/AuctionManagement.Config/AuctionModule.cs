using System;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Persistence.ES;
using Autofac;

namespace AuctionManagement.Config
{
    public class AuctionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuctionRepository>().As<IAuctionRepository>().InstancePerLifetimeScope();
            //....
        }
    }
}
