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
                PrintMenu("Customer Menu");
                Console.WriteLine("-- 'C' to create a new account");
                Console.WriteLine("-- 'R' for account reports");
                Console.WriteLine("-- 'X' to return to main menu");
            }
            if (menu == "Account Creation Menu")
            {
                PrintMenu("Account Creation Menu");
                Console.WriteLine("-- 'C' to open a new account");
                Console.WriteLine("-- 'S' to open a savings account");
                Console.WriteLine("-- 'X' to return to main menu");
            }
            if (menu == "Report Menu")
            {
                PrintMenu("Report Menu");
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
            Console.WriteLine("Enter your email address");
            var email = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Creating your profile and opening your checking account");
            if (customerService.CanOpenCheckingAccount(customer))
            {
                customerService.CreateCustomer(name, email);
            }

            return customer;
        }

        static void PrintMenu(string menuText)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(menuText);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
