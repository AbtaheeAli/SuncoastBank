using System.Collections.Generic;
using System;


namespace FirstBankOfSuncoast
{

    public class Account
    {
        public int Id { get; set; }

        public List<Transaction> Transactions { get; set; }

        public decimal Value { get; set; }



        // public decimal GetBalance();
        // {

        // }
    }
}