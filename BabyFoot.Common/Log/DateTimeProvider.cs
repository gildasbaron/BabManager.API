using System;

namespace BabyFoot.Common.Log
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private readonly DateTime _date;

        public DateTimeProvider()
        {
            _date = DateTime.Now;
        }

        public DateTime Now()
        {
            return _date;
        }
    }
}
