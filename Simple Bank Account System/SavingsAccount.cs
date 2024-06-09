using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Bank_Account_System
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(string accountNumber, string accountHolderName, decimal initialBalance, decimal interestRate)
            : base(accountNumber, accountHolderName, initialBalance)
        {
            InterestRate = interestRate;
        }

        public void CalculateInterest()
        {
            decimal interest = Balance * InterestRate;
            Deposit(interest);
            Console.WriteLine($"Interest calculated: {interest:C}. New Balance: {Balance:C}");
        }
    }
}
