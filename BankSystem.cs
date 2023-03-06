namespace BankAccountTask
{
    public class bankSystem 
    {
        private List<Account> accountList;

        public bankSystem () 
        {
            accountList = new List<Account>();
        }

        private Account FindAccount(int accountNumber) 
        {
            foreach (Account account in accountList) {
                if (account.accNumber == accountNumber) {
                    return account;
                }
            }
            return null;
        }

        public void AddAccount() 
        {
            int accountNumber = RequestAccNumber();
            decimal initialDeposit = RequestAmount();

            if ((!AccountExists(accountNumber) && accountNumber > 0 && initialDeposit > 0)) {
                accountList.Add(new Account(accountNumber, initialDeposit));
                Console.WriteLine("New Account Added Successfully");
            }else {
                Console.WriteLine("Account Number has to be unique " + 
                "and initial deposit must be greater than 0.");
            }
        }

        public void ViewAllAccounts() 
        {
            if (accountList.Count != 0) {
                foreach (Account account in accountList) {
                    Console.WriteLine(account.ToString());
                }
            }else Console.WriteLine("No Account Data Available");
        }

        private bool AccountExists(int accountNumber) 
        {
            foreach (Account account in accountList) {
                if (account.accNumber == accountNumber) {
                    return true;
                }
            }
            return false;
        }

        public void ViewAccount()
        {
            int accountNumber = RequestAccNumber();
            Account account = FindAccount(accountNumber);

            if (account != null) {
                Console.WriteLine(account.ToString());
            }    
        }

        public void MakeDeposit()
        {
            int accountNumber = RequestAccNumber();
            decimal amount = RequestAmount();
            Account account = FindAccount(accountNumber);
            if (account != null && amount > 0) {
                try {
                    account.Deposit(amount);
                }catch (Exception e) {
                    Console.WriteLine(e.Message);
                }

            }else {
                Console.WriteLine("Invalid Details");
            }
            
        }

        public void MakeWithdrawal()
        {
            int accountNumber = RequestAccNumber();
            decimal amount = RequestAmount();
            Account account = FindAccount(accountNumber);
            if (account != null && amount > 0) {
                try {
                    account.Withdraw(amount);
                }catch (Exception e) {
                    Console.WriteLine(e.Message);
                }

            }else {
                Console.WriteLine("Invalid Details");
            }
        }

        private int RequestAccNumber() 
        {
            try {
                Console.WriteLine("Enter Account Number: ");
                return Int32.Parse(Console.ReadLine());

            }catch (FormatException formatException) {
                Console.WriteLine("Invalid Bank Account Number Format");
                return -1;
            }
        }

        private static decimal RequestAmount() 
        {
            try {
                Console.WriteLine("Enter amount to deposit: ");
                return Decimal.Parse(Console.ReadLine());

            }catch (FormatException formatException) {
                Console.WriteLine("Invalid Amount Format");
                return -1;
            }
        }
    }
}