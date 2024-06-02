using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Bank_Account_System
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, string accountHolderName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited: {amount}. New Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Deposit must be positive");
            }
        }

        public void Withdraw(decimal amount)
        {
            if(amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawl amount.");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: {Balance}");
        }
    }
}
