using System;
using TandVark.Domain.Helpers.Interfaces;

namespace TandVark.Domain.Helpers
{
    public class DateTimeProvider:IDateTimeProvider
    {
        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}
