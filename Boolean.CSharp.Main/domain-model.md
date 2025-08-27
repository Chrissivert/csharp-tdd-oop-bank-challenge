# Banking App Domain Model

## Account (abstract class)
Represents a generic bank account. Cannot be instantiated directly.

**Attributes:**
- `AccountNumber : string` – unique identifier for the account
- `Balance : decimal` – current balance of the account
- `Transactions : List<Transaction>` – list of transactions

**Methods:**
- `Deposit(amount : decimal)` – add money to the account
- `Withdraw(amount : decimal)` – remove money from the account
- `GenerateBankStatement()` – generates a bankstatement

---

## CurrentAccount (inherits Account)
Represents a customer’s current account.

**Methods:**  
- Inherits Deposit() and Withdraw() from `Account`

---

## SavingsAccount (inherits Account)
Represents a customer’s savings account.

**Methods:**  
- Inherits Deposit() and Withdraw() from `Account`

---

## Transaction
Represents a single financial operation on an account.

**Attributes:**
- `Amount : decimal` – amount deposited or withdrawn
- `Date : DateTime` – date and time of transaction
- `BalanceAfterTransaction : decimal` – account balance after this transaction


## BankStatement
Represents a collection of transactions.

**Attributes:**
- `Transactions : List<Transaction>` – all transactions in the statement
