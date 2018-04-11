using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Models;

namespace BankWorm.Services
{
    class CustomerService
    {
        private readonly IEnumerable<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>
            {
                new Customer
                {
                    Id = 123,
                    Email = "chris.guitarist009@gmailcom",
                    Name = "Chris McDonald"
                }
            };
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.ToList();
        }
        
        public Customer GetCustomerById(int customerId)
        {
            return _customers.FirstOrDefault(c => c.Id == customerId);
        }

        public void Create(string name, string email)
        {
            var customer = new Customer
            {
                Name = name,
                Email = email
            };

            _customers.ToList().Add(customer);
        }
    }
}