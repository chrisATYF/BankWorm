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

        public EFCustomerService()
        {
            _context = new BankWormEntities();
        }

        public void CreateCustomer(AccountTypes accountTypes)
        {
            Console.WriteLine("Enter your name");
            var enteredName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\nEnter your email address");
            var enteredEmail = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"\nIs this information correct? \nName: {enteredName} \nEmail: {enteredEmail}");
            var reply = Convert.ToString(Console.ReadLine());
            if (reply.ToLower() == "yes")
            {
                var createdCustomer = new Customer
                {
                    Name = enteredName,
                    Email = enteredEmail,
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
                _context.Customers.Add(createdCustomer);
                _context.SaveChanges();
                //return createdCustomer;
            }
        }

        //public Customer CreateCustomer(string name, string email, AccountTypes accountTypes)
        //{
        //    var customer = new Customer
        //    {
        //        Name = name,
        //        Email = email,
        //        CreateDate = DateTime.UtcNow,
        //        Accounts = new List<Account>
        //        {
        //            new Account
        //            {
        //                Name = "Checking",
        //                AccountTypeId = accountTypes
        //            }
        //        }
        //    };

        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //    return customer;
        //}

        public void ReadFile(Customer customer)
        {
            var fileName2 = @"C:\Source\acadotnet\BankWorm\transactionfile-data.csv";
            var lines = File.ReadAllLines(fileName2).ToList().Skip(1);
            var passedCustomer = customer;
            var customerAccount = customer.Accounts.FirstOrDefault();
            
            foreach (var line in lines)
            {
                var cells = line.Split(',');
                var tfv = new Transaction
                {
                    CreateDate = DateTime.Parse(cells[0]),
                    Memo = cells[1],
                    TransactionTypeId = Enums.TransactionTypeExt.TransactionConvertEF(cells[2]),
                    Amount = Convert.ToDecimal(cells[3]),
                };
            }
            
            _context.SaveChanges();
        }
    }
}
