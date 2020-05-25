using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
    class TransactionsController
    {
        private List<Transaction> Transactions = new List<Transaction>();

        public void SaveAllTransactions()
        {
            var writer = new StreamWriter("Transactions.csv");

            var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(Transactions);

            writer.Close();
        }

        public void LoadAllTransactions()
        {
            if (File.Exists("transactions.csv"))
            {
                var reader = new StreamReader("transactions.csv");

                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                Transactions = csvReader.GetRecords<Transaction>().ToList();

            }
        }


        public void RecallTransactionsByTime()
        {
            var orderAccountValueByTime = Transactions.OrderBy(transactions => transactions.TransactionDate);
            foreach (var transaction in orderAccountValueByTime)
            {
                var description = transaction.Description();
                Console.WriteLine(description);
            }

        }

        public void DisplayCheckingAccountBalance()
        {

            var checkingTransaction = Transactions.Where(transactions => transactions.AccountId == 1).ToList();

            var checkingAccountValue = new List<decimal>();

            foreach (var transaction in checkingTransaction)
            {
                checkingAccountValue.Add(transaction.Amount);
            }

            var totalValueForCheckingAccount = checkingAccountValue.Sum();
            Console.WriteLine($"Your current balance of your checking account is {totalValueForCheckingAccount}");


        }

        public void DisplaySavingsAccountBalance()
        {
            var savingsTransaction = Transactions.Where(transactions => transactions.AccountId == 2).ToList();

            var savingsAccountValue = new List<decimal>();

            foreach (var transaction in savingsTransaction)
            {
                savingsAccountValue.Add(transaction.Amount);
            }

            var totalValueForSavingsAccount = savingsAccountValue.Sum();
            Console.WriteLine($"Your current balance of your savings account is {totalValueForSavingsAccount}");
        }

        internal void DepositChecking(Transaction newTransaction)
        {
            Transactions.Add(newTransaction);
        }

        internal void WithdrawChecking(Transaction newTransaction)
        {
            Transactions.Add(newTransaction);
        }

        internal void WithdrawSavings(Transaction newTransaction)
        {
            Transactions.Add(newTransaction);
        }

        internal void DepositSavings(Transaction newTransaction)
        {
            Transactions.Add(newTransaction);
        }
    }
}