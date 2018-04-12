using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Models;
using BankWorm.Services;

namespace BankWorm
{
    public class Program
    {
        private static readonly CustomerService _customerService = new CustomerService();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BankWorm... your protection from the early birds.");

            var isRunning = true;
            while (isRunning)
            {
                PrintMenu("Main Menu");
                Console.WriteLine("-- 'C' to manage customers");
                Console.WriteLine("-- 'R' for reports");
                Console.WriteLine("-- 'Q' to quit");

                var input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "R":
                        Console.WriteLine("Enter customer ID");
                        var reportCustNumber = Convert.ToInt32(Console.ReadLine());
                        var reportCustomer = _customerService.GetCustomerById(reportCustNumber);
                        CustomerReports(reportCustomer);
                        break;

                    case "Q":
                        isRunning = false;
                        break;

                    case "C":
                        ManageCustomerPrompts();
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine("Goodbye");
            Console.ReadLine();
        }

        static void PrintMenu(string menuText)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(menuText);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        static void ManageCustomerPrompts()
        {
            var manageCustomers = true;
            while (manageCustomers)
            {
                PrintMenu("Customer Menu");
                Console.WriteLine("-- 'C' to manage customers");
                Console.WriteLine("-- 'R' for reports");
                Console.WriteLine("-- 'X' to return to main menu");

                var input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "C":
                        Console.WriteLine("Enter customer number");
                        var customerNumber = Convert.ToInt32(Console.ReadLine());
                        var customer = _customerService.GetCustomerById(customerNumber);
                        Console.WriteLine(customer.CustomerName);
                        CreateNewAccount(customer);
                        break;

                    case "R":
                        Console.WriteLine("Enter customer ID");
                        var reportCustNumber = Convert.ToInt32(Console.ReadLine());
                        var reportCustomer = _customerService.GetCustomerById(reportCustNumber);
                        CustomerReports(reportCustomer);
                        break;

                    case "X":
                        manageCustomers = false;
                        break;

                    default:
                        Console.WriteLine("Unrecognized option");
                        break;
                }
            }
        }

        static void CreateNewAccount(Customer customer)
        {
            var creatingAccount = true;
            while (creatingAccount)
            {
                PrintMenu("Account Creation Menu");
                Console.WriteLine("-- 'C' to open a checking account");
                Console.WriteLine("-- 'S' to open a savings account");
                Console.WriteLine("-- 'X' to return to main menu");

                var input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "C":
                        break;
                        
                    case "S":
                        var canOpen = _customerService.CanOpenSavingsaccount(customer);
                        if (canOpen)
                        {
                            Console.WriteLine("Opening savings account.");
                        }
                        else
                        {
                            Console.WriteLine("You have too many savings accounts or no checking account.");
                        }
                        break;

                    case "X":
                        creatingAccount = false;
                        break;
                        
                    default:
                        Console.WriteLine("Unrecognized option");
                        break;
                }
            }
        }

        static void CustomerReports(Customer customer)
        {
            var isReporting = true;
            while (isReporting)
            {
                //TODO: Show all Accounts with current balance
                //TODO: For a given account, supply all transactions by start/end date

                PrintMenu("Report Menu");
                Console.WriteLine("-- 'A' Show all account balances");
                Console.WriteLine("-- 'C' Checking account transactions");
                Console.WriteLine("-- 'S' Savings account transactions");
                Console.WriteLine("-- 'X' to return to main menu");

                var input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "A":
                        Console.WriteLine($"Balance for {customer.CustomerName} is ...");
                        break;

                    case "C":
                        Console.WriteLine($"Checking account transactions for {customer.CustomerName} is ...");
                        break;

                    case "S":
                        Console.WriteLine($"Savings account transactions for {customer.CustomerName} is ...");
                        break;

                    case "X":
                        isReporting = false;
                        break;

                    default:
                        Console.WriteLine("Unrecognized option");
                        break;
                }
            }
        }
    }
}
