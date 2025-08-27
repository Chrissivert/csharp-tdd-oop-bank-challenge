using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void Deposit_IncreasesBalance_CurrentAccount()
        {
            var account = new CurrentAccount();
            account.Deposit(100);
            Assert.AreEqual(100, account.Balance);
        }

        [Test]
        public void Withdraw_DecreasesBalance_CurrentAccount()
        {
            var account = new CurrentAccount();
            account.Deposit(200);
            account.Withdraw(50);
            Assert.AreEqual(150, account.Balance);
        }

        [Test]
        public void Deposit_IncreasesBalance_SavingAccount()
        {
            var account = new SavingAccount();
            account.Deposit(300);
            Assert.AreEqual(300, account.Balance);
        }

        [Test]
        public void Withdraw_DecreasesBalance_SavingAccount()
        {
            var account = new SavingAccount();
            account.Deposit(500);
            account.Withdraw(200);
            Assert.AreEqual(300, account.Balance);
        }

        [Test]
        public void Withdraw_ThrowsException_WhenInsufficientFunds()
        {
            var account = new CurrentAccount();
            account.Deposit(50);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100));
        }

        [Test]
        public void Transactions_AreLoggedCorrectly()
        {
            var account = new CurrentAccount();
            account.Deposit(100);
            account.Withdraw(30);

            Assert.AreEqual(2, account.Transactions.Count);
            Assert.AreEqual(100, account.Transactions[0].Amount);
            Assert.AreEqual(70, account.Transactions[1].BalanceAfterTransaction);
        }

        [Test]
        public void BankStatement_ContainsAllTransactions()
        {
            var account = new CurrentAccount();
            account.Deposit(200);
            account.Withdraw(50);

            var statement = account.GenerateBankStatement();
            Assert.AreEqual(2, statement.Transactions.Count);
            Assert.AreEqual(150, statement.Transactions.Last().BalanceAfterTransaction);
        }

        [Test]
        public void Customer_CanOpenAccounts()
        {
            var customer = new Customer { Name = "Alice" };
            var branch = new Branch("Downtown");   // 🆕 create a branch
            var current = new CurrentAccount();
            var saving = new SavingAccount();

            customer.OpenAccount(current, branch); // 🆕 now pass branch
            customer.OpenAccount(saving, branch);

            Assert.AreEqual(2, customer.Accounts.Count);
            Assert.Contains(current, customer.Accounts);
            Assert.Contains(saving, customer.Accounts);

            // 🆕 optional extra check: branch should also know about accounts
            Assert.AreEqual(2, branch.Accounts.Count);
            Assert.Contains(current, branch.Accounts);
            Assert.Contains(saving, branch.Accounts);
        }

    }
}
