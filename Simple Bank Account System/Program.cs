using System;
using System.Transactions;

namespace Simple_Bank_Account_System
{
    class Program
    {
        static List<Account> accounts = new List<Account>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1. Add Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Calculate Interest (Savings Account)");
                Console.WriteLine("6. Display Transaction History");
                Console.WriteLine("7. EXIT");
                Console.Write("Select an Option: ");

                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            CreateAccount();
                            break;

                        case 2:
                            PerformTransaction(TransactionType.Deposit);
                            break;

                        case 3:
                            PerformTransaction(TransactionType.Withdraw);
                            break;

                        case 4:
                            CheckBalance();
                            break;

                        case 5:
                            CalculateInterest();
                            break;

                        case 6:
                            DisplayTransactionHistory();
                            break;

                        case 7:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter Account Type (savings/current): ");
            string accountType = Console.ReadLine().ToLower();
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter Account Holder Name: ");
            string accountHolderName = Console.ReadLine();
            Console.Write("Enter Initial Balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            if (accountType == "savings")
            {
                Console.Write("Enter Interest Rate: ");
                decimal interestRate = decimal.Parse(Console.ReadLine());
                SavingsAccount savingsAccount = new SavingsAccount(accountNumber, accountHolderName, initialBalance, interestRate);
                accounts.Add(savingsAccount);
                Console.WriteLine("Savings account created successfully.");
            }
            else if (accountType == "current")
            {
                Console.Write("Enter Overdraft Limit: ");
                decimal overdraftLimit = decimal.Parse(Console.ReadLine());
                CurrentAccount currentAccount = new CurrentAccount(accountNumber, accountHolderName, initialBalance, overdraftLimit);
                accounts.Add(currentAccount);
                Console.WriteLine("Current account created successfully.");
            }
            else
            {
                Console.WriteLine("Invalid account type.");
            }
        }

        static void PerformTransaction(TransactionType transactionType)
        {
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            Account account = accounts.Find(a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (transactionType == TransactionType.Deposit)
            {
                account.Deposit(amount);
            }
            else if (transactionType == TransactionType.Withdraw)
            {
                account.Withdraw(amount);
            }
        }

        static void CheckBalance()
        {
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            Account account = accounts.Find(a => a.AccountNumber == accountNumber);

            if (account != null)
            {
                Console.WriteLine($"Account Balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void CalculateInterest()
        {
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            SavingsAccount savingsAccount = accounts.Find(a => a.AccountNumber == accountNumber) as SavingsAccount;

            if (savingsAccount != null)
            {
                savingsAccount.CalculateInterest();
            }
            else
            {
                Console.WriteLine("Savings account not found or invalid account type.");
            }
        }

        static void DisplayTransactionHistory()
        {
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            Account account = accounts.Find(a => a.AccountNumber == accountNumber);

            if (account != null)
            {
                account.DisplayTransactionHistory();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

    enum TransactionType
    {
        Deposit,
        Withdraw
    }
}