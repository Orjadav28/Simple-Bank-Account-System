using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Bank_Account_System
{
    public class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(string accountNumber, string accountHolderName, decimal initialBalance, decimal overdraftLimit)
            : base(accountNumber, accountHolderName, initialBalance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance + OverdraftLimit)
            {
                Balance -= amount;
                TransactionHistory.Add($"Withdrew: {amount:C}. New Balance: {Balance:C}");
                Console.WriteLine($"Withdrew: {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or overdraft limit exceeded.");
            }
        }
    }
}