using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Bank_Account_System
{
    public interface ITransaction
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}
