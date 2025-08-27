public class CurrentAccount : Account
{
    public override void Deposit(decimal amount)
    {
        base.Deposit(amount); // important to call base
    }

    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount); // keeps transaction logging
    }
}
