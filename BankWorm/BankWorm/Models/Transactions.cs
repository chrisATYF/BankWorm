﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankWorm.Enums;

namespace BankWorm.Models
{
    class Transactions
    {
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TypeOfTransaction { get; set; }
    }
}