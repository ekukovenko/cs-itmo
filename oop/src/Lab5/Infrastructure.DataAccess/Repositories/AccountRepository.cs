using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Models;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async void UpdateBalance(Account account, long money)
    {
        const string sql = """
                            UPDATE accounts
                            SET account_balance = :balance
                            WHERE account_id = :accountId
                            """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("balance", account.Balance.Value);
        command.Parameters.AddWithValue("accountId", account.Id);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<Account?> GetAccountByName(string name)
    {
        const string sql = """
                           SELECT account_id, account_name, account_pin, account_balance
                           FROM accounts
                           WHERE account_name = :accountName
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_name", name);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
        {
            return null;
        }

        return new Account(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetInt32(2),
                new Balance(reader.GetInt64(3)));
    }

    public async Task<Account?> GetAccountById(long id)
    {
        const string sql = """
                           SELECT account_id, account_name, account_pin, account_balance
                           FROM accounts
                           WHERE account_name = :accountName
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("accountId", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            return new Account(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetInt32(2),
                new Balance(reader.GetInt64(3)));
        }

        return null;
    }
}