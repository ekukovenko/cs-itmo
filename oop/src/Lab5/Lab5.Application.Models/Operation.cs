namespace Lab5.Models;

public record Operation(long AccountId, long Id, AccountOperationType Type, long BalanceDiff);