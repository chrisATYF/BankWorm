using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWorm.Enums
{
    public enum TransactionType
    {
        Debit,
        Credit
    }

    public static class TransactionTypeExt
    {
        public static TransactionType TransactionConvert(string transactionType)
        {
            if (transactionType == "Debit")
            {
                return TransactionType.Debit;
            }
            return TransactionType.Credit;
        }
    }
}
