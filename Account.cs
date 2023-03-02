using System.Text;
namespace BankAccountTask
{
    class Account
    {
        public int accNumber { get; set; }
        public decimal balance { get; set; }
        public List<Transaction> transactions { get; }

        public Account(int accountNumber, decimal initialBalance) {
            accNumber = accountNumber;
            balance = initialBalance;
            transactions = new List<Transaction>{};
        }

        public void Withdraw(decimal amount) {
            if (balance < amount) {
                throw new Exception($"Cannot withdraw {amount} from current balance");
            }
            balance -= amount;
            transactions.Add(new Transaction(amount, ACTION_TYPE.WITHDRAWAL));
        }

        public void Deposit(decimal amount) {
            if (amount <= 0)
                throw new Exception("Cannot deposit amounts equal or less than zero(0)");
            balance += amount;
            transactions.Add(new Transaction(amount, ACTION_TYPE.DEPOSIT));
        }

        public string TransactionHistory() {

            StringBuilder transHistory = new StringBuilder();
            foreach (Transaction transaction in transactions) {
                    transHistory.AppendLine(transaction.ToString());
            }
            return transHistory.ToString();

        }

        public override string ToString()
        {
            string transactionHistory = TransactionHistory();
            return $"Account Number: {accNumber.ToString()}\n" +
                   $"Balance: {balance.ToString()}\n" + 
                   $"Transaction History: \n{transactionHistory}"; 
        }
    }
}