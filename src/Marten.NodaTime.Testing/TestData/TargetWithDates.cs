using System;
using NodaTime;

namespace Marten.NodaTime.Testing.TestData
{
    public class TargetWithDates
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? NullableDateTime { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public DateTimeOffset? NullableDateTimeOffset { get; set; }

        public LocalDate LocalDate { get; set; }
        public LocalDate? NullableLocalDate { get; set; }
        public LocalDateTime LocalDateTime { get; set; }
        public LocalDateTime? NullableLocalDateTime { get; set; }

        internal static TargetWithDates Generate()
        {
            var dateTime = DateTime.UtcNow;
            var localDateTime = LocalDateTime.FromDateTime(dateTime);

            return new TargetWithDates
            {
                Id = Guid.NewGuid(),
                DateTime = dateTime,
                NullableDateTime = dateTime,
                DateTimeOffset = dateTime,
                NullableDateTimeOffset = dateTime,
                LocalDate = localDateTime.Date,
                NullableLocalDate = localDateTime.Date,
                LocalDateTime = localDateTime,
                NullableLocalDateTime = localDateTime
            };
        }
    }
}