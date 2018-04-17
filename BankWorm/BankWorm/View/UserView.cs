 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Models;
using BankWorm.Services;

namespace BankWorm.View
{
    public class UserView
    {
        public void WelcomeScreen(string menu)
        {
            if (menu == "Main Menu")
            {
                PrintMenu($"{menu}");
                Console.WriteLine("-- 'C' to manage customers");
                Console.WriteLine("-- 'R' for reports");
                Console.WriteLine("-- 'Q' to quit");
            }
            if (menu == "Customer Menu")
            {
                PrintMenu($"{menu}");
                Console.WriteLine("-- 'C' to create a new account");
                Console.WriteLine("-- 'R' for account reports");
                Console.WriteLine("-- 'X' to return to main menu");
            }
            if (menu == "Account Creation Menu")
            {
                PrintMenu($"{menu}");
                Console.WriteLine("-- 'C' to open a new account");
                Console.WriteLine("-- 'S' to open a savings account");
                Console.WriteLine("-- 'X' to return to main menu");
            }
            if (menu == "Report Menu")
            {
                PrintMenu($"{menu}");
                Console.WriteLine("-- 'A' Show all account balances");
                Console.WriteLine("-- 'C' Checking account transactions");
                Console.WriteLine("-- 'S' Savings account transactions");
                Console.WriteLine("-- 'X' to return to main menu");
            }
        }

        public Customer CustomerReport(CustomerService customerService)
        {
            Console.WriteLine("Enter customer ID");
            var reportCustNumber = Convert.ToInt32(Console.ReadLine());
            var reportCustomer = customerService.GetCustomerById(reportCustNumber);
            return reportCustomer;
        }

        public Customer CustomerAccess(CustomerService customerService)
        {
            Console.WriteLine("Enter customer number");
            var customerNumber = Convert.ToInt32(Console.ReadLine());
            var customer = customerService.GetCustomerById(customerNumber);
            Console.WriteLine(customer.CustomerName);
            return customer;
        }

        public Customer CreateACustomer(CustomerService customerService, Customer customer)
        {
            Console.WriteLine("Enter your name");
            var name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\nEnter your email address");
            var email = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"\nIs this information correct? \nName: {name} \nEmail: {email}");
            var reply = Convert.ToString(Console.ReadLine());
            if (reply.ToLower() == "yes")
            {
                Console.WriteLine("\nCreating your profile and opening your checking account");
                if (customerService.CanOpenCheckingAccount(customer))
                {
                    customerService.CreateCustomer(name, email);
                }
            }
            else if (reply.ToLower() == "no")
            {
                Console.WriteLine("\nBack up and try again");
            }

            return customer;
        }

        public void CheckingTransactionDates(CustomerService customerService, Customer customer, Account account)
        {
            Console.WriteLine("Enter a start date");
            var startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter an end date");
            var endDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"Checking account transaction dates for {customer.CustomerName}:\n");
            var listOfDates = customerService.TransactionLists(account);
            var requestedDates = listOfDates.Where
                (rd => rd.TransactionDate >= startDate
                && rd.TransactionDate <= endDate).Select(td => td.TransactionDate).ToList();
            foreach (var td in requestedDates)
            {
                Console.WriteLine($"{td}\n");
            }
        }

        public void SavingsTransactionDates(CustomerService customerService, Customer customer, Account account)
        {
            Console.WriteLine("Enter a start date");
            var startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter an end date");
            var endDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"Savings account transaction dates for {customer.CustomerName}:\n");
            var listOfDates = customerService.TransactionLists(account);
            var requestedDates = listOfDates.Where
                (rd => rd.TransactionDate >= startDate
                && rd.TransactionDate <= endDate).Select(td => td.TransactionDate).ToList();
            foreach (var td in requestedDates)
            {
                Console.WriteLine($"{td}\n");
            }
        }

        static void PrintMenu(string menuText)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(menuText);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
