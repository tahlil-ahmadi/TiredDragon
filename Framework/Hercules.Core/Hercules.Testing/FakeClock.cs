using System;
using Hercules.Core.Clock;

namespace Hercules.Testing
{
    public class StubClock : IClock
    {
        private DateTime _now;
        public void SetNowAs(DateTime dateTime)
        {
            this._now = dateTime;
        }
        public void SetNowAsSomePastDate()
        {
            this._now = DateTime.Now.AddDays(-1);
        }
        public void SetNowAsSomeFutureDate()
        {
            this._now = DateTime.Now.AddDays(1);
        }
        public DateTime Now()
        {
            return _now;
        }
    }
}
