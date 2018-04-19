using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Data;

namespace BankWorm.Services
{
    public class EFCustomerService
    {
        private readonly BankWormEntities _context;
        
        public EFCustomerService()
        {
            _context = new BankWormEntities();

            var newCustomer = new Customer
            {
                Email = "chris.guitarist009@gmailcom",
                Name = "Chris McDonald",
                CreateDate = DateTime.UtcNow,
            };

            newCustomer.Accounts.Add(new Account
            {
                Name = "Main Checking",
                AccountTypeId = AccountTypes.Checking
            });
            _context.Customers.Add(newCustomer);

            _context.SaveChanges();
        }
    }
}
