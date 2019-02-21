using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.Framework
{
    public interface IClock
    {
        DateTime Now();
    }
}
