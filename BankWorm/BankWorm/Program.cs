using System;
using System.IO;
using System.Linq;
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
                        CustomerReports(userView.CustomerReport(_customerService));
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
                        CreateNewAccount(userView.CustomerAccess(_customerService));
                        break;

                    case "R":
                        CustomerReports(userView.CustomerReport(_customerService));
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
                        userView.CreateACustomer(_customerService, customer);
                        break;

                    case "S":
                        if (_customerService.CanOpenSavingsaccount(customer))
                        {
                            Console.WriteLine("Opening savings account.");
                            _customerService.CreateCustomer(customer.CustomerName, customer.CustomerEmail);
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
                        Console.WriteLine("Enter checking or savings");
                        var accountType = Convert.ToString(Console.ReadLine());
                        if (accountType.ToLower() == "Checking")
                        {
                            Console.WriteLine("Enter a start date");
                            var startDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Enter an end date");
                            var endDate = Convert.ToDateTime(Console.ReadLine());
                            foreach (var account in customer.Accounts)
                            {
                                _customerService.PopulateAccount(account);
                                var dates = account.Transactions.Where(t => t.TransactionDate == startDate);
                            }
                        }
                        else if (accountType.ToLower() == "savings")
                        {
                            Console.WriteLine("Enter a start date");
                            var startDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Enter an end date");
                            var endDate = Convert.ToDateTime(Console.ReadLine());
                        }
                        Console.WriteLine($"Checking account transaction dates for {customer.CustomerName} are ...");
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
