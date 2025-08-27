using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void Account_IsAssociatedWithBranch_WhenOpened()
        {
            var customer = new Customer { Name = "Bob" };
            var branch = new Branch("Central");
            var account = new CurrentAccount();

            customer.OpenAccount(account, branch);

            Assert.AreEqual(branch, account.Branch);
            Assert.Contains(account, branch.Accounts);
        }

        [Test]
        public void Customer_CanRequestOverdraft()
        {
            var customer = new Customer { Name = "Carol" };
            var branch = new Branch("Uptown");
            var account = new CurrentAccount();

            customer.OpenAccount(account, branch);
            customer.RequestOverdraft(account, 500);

            Assert.AreEqual(500, account.OverdraftLimit);
            Assert.IsFalse(account.OverdraftApproved);
        }

        [Test]
        public void Manager_CanApproveOverdraft()
        {
            var branch = new Branch("Central");
            var account = new CurrentAccount();

            branch.Accounts.Add(account);
            account.RequestOverdraft(300);

            branch.ApproveOverdraft(account);

            Assert.IsTrue(account.OverdraftApproved);
            Assert.AreEqual(300, account.OverdraftLimit);
        }

        [Test]
        public void Manager_CanRejectOverdraft()
        {
            var branch = new Branch("Central");
            var account = new CurrentAccount();

            branch.Accounts.Add(account);
            account.RequestOverdraft(400);

            branch.RejectOverdraft(account);

            Assert.AreEqual(0, account.OverdraftLimit);
            Assert.IsFalse(account.OverdraftApproved);
        }

        [Test]
        public void Withdraw_AllowsOverdraft_AfterApproval()
        {
            var branch = new Branch("Central");
            var account = new CurrentAccount();
            account.RequestOverdraft(200);
            branch.ApproveOverdraft(account);

            account.Deposit(50);
            account.Withdraw(200); 

            Assert.AreEqual(-150, account.Balance);
        }

        [Test]
        public void Withdraw_Throws_WhenOverdraftNotApproved()
        {
            var branch = new Branch("Central");
            var account = new CurrentAccount();

            branch.Accounts.Add(account);
            account.RequestOverdraft(200);
            account.Deposit(50);

            Assert.Throws<InvalidOperationException>(() => account.Withdraw(200));
        }

        [Test]
        public void Customer_CanReceiveStatementAsSms()
        {
            var customer = new Customer { Name = "Dana", PhoneNumber = "12345" };
            var branch = new Branch("West End");
            var account = new CurrentAccount();

            customer.OpenAccount(account, branch);
            account.Deposit(100);
            account.Withdraw(30);

            Assert.DoesNotThrow(() => customer.ReceiveStatement(account));
        }
    }
}
