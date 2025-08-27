public class Branch
{
    public string Name { get; set; }
    public List<Account> Accounts { get; set; } = new List<Account>();

    public Branch(string name)
    {
        Name = name;
    }

    public void ApproveOverdraft(Account account)
    {
        account.ApproveOverdraft();
        Console.WriteLine($"Overdraft approved for account at {Name}");
    }

    public void RejectOverdraft(Account account)
    {
        account.RejectOverdraft();
        Console.WriteLine($"Overdraft rejected for account at {Name}");
    }
}