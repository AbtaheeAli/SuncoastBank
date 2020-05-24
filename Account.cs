using System.Collections.Generic;
using System;


namespace FirstBankOfSuncoast
{

    public class Account
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public List<Transaction> Transactions { get; set; }
        public DateTime TransactionDate { get; set; }



        // public decimal GetBalance();
        // {

        // }
    }
}