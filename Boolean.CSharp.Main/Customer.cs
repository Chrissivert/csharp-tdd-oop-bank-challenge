public class Customer
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public List<Account> Accounts { get; set; } = new List<Account>();

    public void OpenAccount(Account account, Branch branch)
    {
        account.Branch = branch;
        Accounts.Add(account);
        branch.Accounts.Add(account);
    }

    public void RequestOverdraft(Account account, decimal limit)
    {
        account.RequestOverdraft(limit);
    }

    public void ReceiveStatement(Account account)
    {
        var statement = new BankStatement(account.Transactions);
        statement.SendAsSms(PhoneNumber);
    }
}