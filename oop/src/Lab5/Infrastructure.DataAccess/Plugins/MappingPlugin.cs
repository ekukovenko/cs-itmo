using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Models;
using Npgsql;

namespace Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<AccountOperationType>();
    }
}