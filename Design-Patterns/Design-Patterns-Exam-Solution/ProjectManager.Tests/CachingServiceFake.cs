using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests
{
    public class CachingServiceFake : CachingService
    {
        public CachingServiceFake(TimeSpan duration, IDateTimeProvider dateTimeProvider) : base(duration, dateTimeProvider)
        {
        }

        public TimeSpan Duration
        {
            get { return this.duration; }
        }

        public DateTime TimeExpiring
        {
            get { return this.timeExpiring; }
        }

        public IDictionary<string, object> Cache
        {
            get { return this.cache; }
        }
    }
}
