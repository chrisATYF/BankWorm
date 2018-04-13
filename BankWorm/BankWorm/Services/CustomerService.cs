using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Models;
using BankWorm.Enums;
using System.IO;

namespace BankWorm.Services
{
    public class CustomerService
    {
        private readonly List<Customer> _customers;
        private readonly Random _random = new Random();

        public CustomerService()
        {
            _customers = new List<Customer>
            {
                new Customer
                {
                    Id = 123,
                    CustomerEmail = "chris.guitarist009@gmailcom",
                    CustomerName = "Chris McDonald",
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            AccountName = "test1",
                            AccountNumber = Guid.NewGuid(),
                            Type = AccountType.Savings,
                            Transactions = new List<Transactions>()
                        },

                        new Account
                        {
                            AccountName = "test2",
                            AccountNumber = Guid.NewGuid(),
                            Type = AccountType.Checking,
                            Transactions = new List<Transactions>()
                        }
                    },
                }
            };
        }



        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.ToList();
        }

        public bool CanOpenSavingsaccount(Customer customer)
        {
            var c = _customers.Where(r => r.Id == customer.Id).FirstOrDefault();
            var a = c.Accounts.Any(i => i.Type == AccountType.Checking);

            if (!a)
            {
                return false;
            }

            var numOfAccounts = c.Accounts.Where(n => n.Type == AccountType.Savings).Count();
            if (numOfAccounts == 2)
            {
                return false;
            }

            return true;
        }
        
        public Customer GetCustomerById(int customerId)
        {
            return _customers.FirstOrDefault(c => c.Id == customerId);
        }

        public void Create(string name, string email)
        {
            var customer = new Customer
            {
                Id = _random.Next(1, 10000000),
                CustomerName = name,
                CustomerEmail = email
            };

            _customers.ToList().Add(customer);
        }

        public void PopulateAccount(Account accountToPopulate)
        {
            try
            {
                var fileName1 = "C:\\Source\\acadotnet\\BankWorm\\transactionfile.csv";
                var fileName2 = @"C:\Source\acadotnet\BankWorm\transactionfile-data.csv";

                var lines = File.ReadAllLines(fileName2).ToList().Skip(1);
                if (accountToPopulate.Transactions == null)
                {
                    accountToPopulate.Transactions = new List<Transactions>();
                }
                foreach (var line in lines)
                {
                    var cells = line.Split(',');

                    var tfv = new Transactions
                    {
                        TransactionDate = DateTime.Parse(cells[0]),
                        Memo = cells[1],
                        TypeOfTransaction = TransactionTypeExt.TransactionConvert(cells[2]),
                        Amount = Convert.ToDecimal(cells[3]),
                    };
                    accountToPopulate.Transactions.Add(tfv);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}