 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("-- 'C' to manage customers");
                Console.WriteLine("-- 'R' for reports");
                Console.WriteLine("-- 'X' to return to main menu");
            }
            if (menu == "Account Creation Menu")
            {
                PrintMenu("Account Creation Menu");
                Console.WriteLine("-- 'C' to open a checking account");
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

        static void PrintMenu(string menuText)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(menuText);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
