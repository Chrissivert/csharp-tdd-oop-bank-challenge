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
    }

    public void RejectOverdraft(Account account)
    {
        account.RejectOverdraft();
    }
}