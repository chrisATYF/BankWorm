using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Enums;

namespace BankWorm.Models
{
    class Accounts
    {
        public int AccountNumber { get; private set; }
        private AccountType Type;
        public string AccountName { get; set; }
        public IEnumerable<Transactions> Balance { get; set; }
    }
}
