public abstract class Account
{
    public List<Transaction> Transactions { get; } = new List<Transaction>();
    public Branch Branch { get; set; }
    public decimal OverdraftLimit { get; private set; } = 0;
    public bool OverdraftApproved { get; private set; } = false;
    public decimal Balance => Transactions.Sum(t => t.Amount);

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Deposit must be positive");
        Transactions.Add(new Transaction(amount, DateTime.Now, Balance + amount));
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Withdrawal must be positive");

        var effectiveOverdraft = OverdraftApproved ? OverdraftLimit : 0;

        if (Balance - amount < -effectiveOverdraft)
            throw new InvalidOperationException("Insufficient funds, overdraft limit reached");

        Transactions.Add(new Transaction(-amount, DateTime.Now, Balance - amount));
    }


    public void RequestOverdraft(decimal limit)
    {
        OverdraftLimit = limit;
        OverdraftApproved = false;
    }

    public void ApproveOverdraft()
    {
        OverdraftApproved = true;
    }

    public void RejectOverdraft()
    {
        OverdraftLimit = 0;
        OverdraftApproved = false;
    }

    public BankStatement GenerateBankStatement()
    {
        return new BankStatement(Transactions);
    }
}