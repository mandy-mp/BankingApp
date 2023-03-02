using BankAccountTask;

internal class Program
{
    private static void Main(string[] args)
    {
        int runApp = 0;

        Console.WriteLine("Welcome to My Banking App!");
        do {
            int transaction = GetUserInput();
            switch (transaction) {
                case 1: 
                    BankSystem.AddAccount();
                    break;
                case 2:
                    BankSystem.ViewAccount();
                    break;
                case 3:
                    BankSystem.MakeDeposit();
                    break;
                case 4:
                    BankSystem.MakeWithdrawal();
                    break;
                case 5:
                    BankSystem.ViewAllAccounts();
                    break;
                case 6:
                runApp = 6;
                    break;   
                default:
                    break;

            }
        }while (runApp != 6);
        
    }

    private static int GetUserInput() {

        int transactionNumb = 0;

        Console.WriteLine("\nChoose a transaction from the list below: \n" +
                        "1. Add New Account\n" +
                        "2. View Account Details\n" +
                        "3. Deposit\n" +
                        "4. Withdrawal\n" +
                        "5. View All Existing Accounts\n" + 
                        "6. Exit");

        string usersChoice = Console.ReadLine();

        try {
            transactionNumb = Int32.Parse(usersChoice);
            if (transactionNumb >= 1 && transactionNumb <= 6) {
                return transactionNumb;
            }else return 0;

        }catch (Exception e) {
            Console.WriteLine(e.Message);
            return 0;
        }

    }


        
}

   
