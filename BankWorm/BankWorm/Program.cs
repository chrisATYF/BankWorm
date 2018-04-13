using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Models;
using BankWorm.Services;
using BankWorm.View;

namespace BankWorm
{
    public class Program
    {
        private static readonly CustomerService _customerService = new CustomerService();
        public static UserView userView = new UserView();
        public static string WelcomeMessage = "Main Menu";
        public static string CustomerMessage = "Customer Menu";
        public static string CreationMessage = "Account Creation Menu";
        public static string ReportMessage = "Report Menu";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BankWorm... your protection from the early birds.");

            var isRunning = true;
            while (isRunning)
            {
                userView.WelcomeScreen(WelcomeMessage);

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
                userView.WelcomeScreen(CustomerMessage);

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
                userView.WelcomeScreen(CreationMessage);

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
                //TODO: For a given account, supply all transactions by start/end date
                userView.WelcomeScreen(ReportMessage);

                var input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "A":
                        foreach (var account in customer.Accounts)
                        {
                            _customerService.PopulateAccount(account);
                            Console.WriteLine($"Balance for {account.Type} {account.AccountName} is {account.AvailableBalance().ToString("C")}");
                        }
                        break;

                    case "C":
                        Console.WriteLine($"Checking account transaction dates for {customer.CustomerName} is ...");
                        break;

                    case "S":
                        Console.WriteLine($"Savings account transaction dates for {customer.CustomerName} is ...");
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
