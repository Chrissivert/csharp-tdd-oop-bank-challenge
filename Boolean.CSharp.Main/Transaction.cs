public class Transaction
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public decimal BalanceAfterTransaction { get; set; }

    public Transaction(decimal amount, DateTime date, decimal balance)
    {
        Amount = amount;
        Date = date;
        BalanceAfterTransaction = balance;
    }
}