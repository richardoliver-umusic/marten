using Marten.Linq.Parsing;
using Marten.Services;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using Npgsql;

namespace Marten.NodaTime
{
    public static class NodaTimeExtensions
    {
        public static void UseNodaTime(this StoreOptions storeOptions)
        {
            NpgsqlConnection.GlobalTypeMapper.UseNodaTime();

            storeOptions.Linq.MethodCallParsers.Add(new SimpleNodaTimeEqualsParser());
            storeOptions.Linq.MethodCallParsers.Add(new SimpleNodaTimeNotEqualsParser());

            var serializer = new JsonNetSerializer();
            serializer.Customize(s => s.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));

            storeOptions.Serializer(serializer);
        }
    }
}