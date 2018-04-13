using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWorm.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
