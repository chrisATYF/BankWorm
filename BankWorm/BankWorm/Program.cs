using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Services;

namespace BankWorm
{
    class Program
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
    }
}
