using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Bank_Account_System
{
    public class Bank
    {
        private List<Account> accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            accounts.Add(account);
            Console.WriteLine($"Account for {account.AccountHolderName} added succsessfully");

        }
        public Account FindAcoount(string accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }

        public void DisplayAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Holder: {account.AccountHolderName}, Balance: {account.Balance}");
            }
        }
    }
}
