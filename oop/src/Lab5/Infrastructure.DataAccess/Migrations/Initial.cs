using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]

public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type operation_type as enum
        (
            'CheckBalance',
            'WithdrawMoney',
            'AddMoney'
        );

        create table accounts
        (
            account_id bigint primary key generated always as identity ,
            account_name text not null,
            account_pin int not null,
            account_balance bigint not null
        );

        create table operations
        (
            operations_id bigint primary key generated always as identity ,
            account_id bigint not null references accounts(account_id),
            operation operation_type not null,
            balance_diff bigint not null
        );

        create table admin
        (
            admin_id bigint primary key generated always as identity,
            admin_name text not null,
            admin_password int not null
        );

        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table Accounts;
        drop table accounts;
        drop table operations;
        drop type Account_role;
        drop type operation_type;
        """;
}