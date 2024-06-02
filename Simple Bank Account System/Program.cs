using System;

namespace Simple_Bank_Account_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n1. Add Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Display All Account");
                Console.WriteLine("6. EXIT");
                Console.WriteLine("Select Option: ");

                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter Account NUmber: ");
                            string accNumber = Console.ReadLine();
                            Console.Write("Enter Account Holder Name: ");
                            string accHolderNamae = Console.ReadLine();
                            Console.Write("Enter Initial BAlance: ");
                            decimal initialBalance;
                            if (decimal.TryParse(Console.ReadLine(), out initialBalance))
                            {
                                Account newAccount = new Account(accNumber, accHolderNamae, initialBalance);
                                bank.AddAccount(newAccount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid inital balance.");
                            }
                            break;

                        case 2:
                            Console.Write("Enter Account Number: ");
                            accNumber = Console.ReadLine();
                            Account depositAccount = bank.FindAcoount(accNumber);
                            if (depositAccount != null)
                            {
                                Console.Write("Enter Amount to Deposit: ");
                                decimal depositAmount;
                                if (decimal.TryParse(Console.ReadLine(), out depositAmount))
                                {
                                    depositAccount.Deposit(depositAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid deposit amount. ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account not Found. ");
                            }
                            break;

                        case 3:
                            Console.Write("Enter Account NUmber: ");
                            accNumber = Console.ReadLine();
                            Account withdrawAccount = bank.FindAcoount(accNumber);
                            if (withdrawAccount != null)
                            {
                                Console.Write("Enter Amount to Withdraw: ");
                                decimal withdrawAmount;
                                if (decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                                {
                                    withdrawAccount.Withdraw(withdrawAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid withdraw amount. ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account not Found. ");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Enter Account Number: ");
                            accNumber = Console.ReadLine();
                            Account balanceAccount = bank.FindAcoount(accNumber);
                            if (balanceAccount != null)
                            {
                                balanceAccount.CheckBalance();
                            }
                            else
                            {
                                Console.WriteLine("Account not Found. ");
                            }
                            break;

                        case 5:
                            bank.DisplayAccounts();
                            break;

                        case 6:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid optioon. Try Again. ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a nummber. ");
                }
            }
        }
    }
}