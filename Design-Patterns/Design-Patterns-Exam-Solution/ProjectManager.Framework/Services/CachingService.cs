using System;
using System.Collections.Generic;

using Bytes2you.Validation;

namespace ProjectManager.Framework.Services
{
    public class CachingService : ICachingService
    {
        protected readonly TimeSpan duration;
        protected DateTime timeExpiring;
        protected IDateTimeProvider dateTimeProvider;

        protected IDictionary<string, object> cache;

        public CachingService(TimeSpan duration, IDateTimeProvider dateTimeProvider)
        {
            Guard.WhenArgument(duration, "duration").IsLessThan(TimeSpan.Zero).Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTime").IsNull().Throw();

            this.duration = duration;
            this.dateTimeProvider = dateTimeProvider;
            this.timeExpiring = this.dateTimeProvider.Now;
            this.cache = new Dictionary<string, object>();
        }

        public void ResetCache()
        {
            this.cache = new Dictionary<string, object>();
            this.timeExpiring = this.dateTimeProvider.Now + this.duration;
        }

        public bool IsExpired
        {
            get
            {
                if (this.timeExpiring < this.dateTimeProvider.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public object GetCacheValue(string className, string methodName)
        {
            return this.cache[$"{className}.{methodName}"];
        }

        public void AddCacheValue(string className, string methodName, object value)
        {
            this.cache.Add($"{className}.{methodName}", value);
        }
    }
}
