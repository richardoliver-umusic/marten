using System.Linq;
using Marten.NodaTime.Testing.TestData;
using Marten.Testing;
using Shouldly;
using Xunit;

namespace Marten.NodaTime.Testing.Acceptance
{
    public class noda_time_acceptance : IntegratedFixture
    {
        [Fact]
        public void can_insert_document()
        {
            StoreOptions(_ => _.UseNodaTime());

            var testDoc = TargetWithDates.Generate();

            using (var session = theStore.OpenSession())
            {
                session.Insert(testDoc);
                session.SaveChanges();
            }

            using (var query = theStore.QuerySession())
            {
                var docFromDb = query.Query<TargetWithDates>().FirstOrDefault(d => d.Id == testDoc.Id);

                docFromDb.ShouldNotBeNull();
                docFromDb.DateTime.ShouldBe(testDoc.DateTime);
                docFromDb.NullableDateTime.ShouldBe(testDoc.NullableDateTime);
                docFromDb.DateTimeOffset.ShouldBe(testDoc.DateTimeOffset);
                docFromDb.NullableDateTimeOffset.ShouldBe(testDoc.NullableDateTimeOffset);
                docFromDb.LocalDate.ShouldBe(testDoc.LocalDate);
                docFromDb.NullableLocalDate.ShouldBe(testDoc.NullableLocalDate);
                docFromDb.LocalDateTime.ShouldBe(testDoc.LocalDateTime);
                docFromDb.NullableLocalDateTime.ShouldBe(testDoc.NullableLocalDateTime);
            }
        }
    }
}