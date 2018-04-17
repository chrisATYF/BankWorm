using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Enums;

namespace BankWorm.Models
{
    public class Account
    {
        public Guid AccountNumber = new Guid();
        public AccountType Type;
        public string AccountName { get; set; }
        public List<Transactions> Transactions { get; set; }
        public int Id { get; set; }

        public bool HasReachedWithdrawalLimit(TransactionType type, AccountType accountType)
        {
            if (type == TransactionType.Debit)
            {
                var date = DateTime.Now.AddDays(-30);
                var pastTransactions = Transactions.Where(t => t.TransactionDate > date).Count();
                if (pastTransactions == 3)
                {
                    Console.WriteLine("You have reached your withdrawal limit.");
                }
            }
            
            return true;
        }

        public decimal Withdrawal(TransactionType type, AccountType accountType, decimal WithdrawalAmount, Transactions transactions)
        {
            if (HasReachedWithdrawalLimit(type, accountType))
            {
                if (accountType == AccountType.Checking)
                {
                    if (transactions.Amount <= WithdrawalAmount)
                    {
                        var overdraftFee = 15;
                        return transactions.Amount - overdraftFee;
                    }
                }
                else
                {
                    if (transactions.Amount <= WithdrawalAmount)
                    {
                        var overdraftFee = 20;
                        return WithdrawalAmount - overdraftFee;
                    }
                }

                return WithdrawalAmount;
            }
            else
            {
                return 0;
            }
        }

        public decimal Deposit(TransactionType type, AccountType accountType, decimal DepositAmount, Transactions transactions)
        {
            return DepositAmount + transactions.Amount;
        }

        public decimal AvailableBalance()
        {
            return Transactions.Sum(t => t.Amount);
        }
    }
}
