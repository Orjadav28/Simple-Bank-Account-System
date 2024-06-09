using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Bank_Account_System
{
    public class Account : ITransaction
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; protected set; }
        public List<string> TransactionHistory { get; private set; }

        public Account(string accountNumber, string accountHolderName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
            TransactionHistory = new List<string>();
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                TransactionHistory.Add($"Deposited: {amount:C}. New Balance: {Balance:C}");
                Console.WriteLine($"Deposited: {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit must be positive.");
            }
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                TransactionHistory.Add($"Withdrew: {amount:C}. New Balance: {Balance:C}");
                Console.WriteLine($"Withdrew: {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
            }
        }

        public void DisplayTransactionHistory()
        {
            Console.WriteLine("Transaction History:");
            foreach (var transaction in TransactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}