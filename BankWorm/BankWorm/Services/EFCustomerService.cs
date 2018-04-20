using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Data;

namespace BankWorm.Services
{
    public class EFCustomerService
    {
        private readonly BankWormEntities _context;
        private readonly Random _random = new Random();

        public EFCustomerService()
        {
            _context = new BankWormEntities();

            //var fileName2 = @"C:\Source\acadotnet\BankWorm\transactionfile-data.csv";
            //var lines = File.ReadAllLines(fileName2).ToList().Skip(1);

            //var theAccount = new Account
            //{
            //    Name = "Main Account",
            //    AccountTypeId = AccountTypes.Checking
            //};

            //var theCustomer = new Customer
            //{
            //    Name = "David Bowie",
            //    Email = "totallyAwesome@gmail.com",
            //    CreateDate = DateTime.UtcNow
            //};
            //theCustomer.Accounts.Add(theAccount);

            //foreach (var line in lines)
            //{
            //    var cells = line.Split(',');
            //    var tfv = new Transaction
            //    {
            //        CreateDate = DateTime.Parse(cells[0]),
            //        Memo = cells[1],
            //        TransactionTypeId = Enums.TransactionTypeExt.TransactionConvertEF(cells[2]),
            //        Amount = Convert.ToDecimal(cells[3]),
            //    };
            //    theAccount.Transactions.Add(tfv);
            //}

            //_context.Customers.Add(theCustomer);
            _context.SaveChanges();
        }

        public void CreateCustomer(string name, string email, AccountTypes accountTypes)
        {
            var customer = new Customer
            {
                Name = name,
                Email = email,
                CreateDate = DateTime.UtcNow,
                Accounts = new List<Account>
                {
                    new Account
                    {
                        Name = "Checking",
                        AccountTypeId = accountTypes
                    }
                }
            };
            
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
