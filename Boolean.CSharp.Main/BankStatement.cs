public class BankStatement
{
    public List<Transaction> Transactions { get; set; }

    public BankStatement(List<Transaction> transactions)
    {
        Transactions = transactions;
    }

    public void PrintStatement()
    {
        foreach (var t in Transactions)
        {
            Console.WriteLine($"{t.Date.ToShortDateString()} | {t.Amount} | {t.BalanceAfterTransaction}");
        }
    }

    public void SendAsSms(string phoneNumber)
    {
        Console.WriteLine($"Sending SMS to {phoneNumber}...");
        foreach (var t in Transactions)
        {
            Console.WriteLine($"[SMS to {phoneNumber}] {t.Date.ToShortDateString()} | {t.Amount} | {t.BalanceAfterTransaction}");
        }
    }
}