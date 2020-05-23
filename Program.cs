using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
    class Program
    {
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        static int PromptForDecimal(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static void Main(string[] args)
        {


            var checkingAccount = new Account()
            {
                Id = 1,
                AccountType = "Checking",
                Transactions = new List<Transaction>()
            };

            var savingsAccount = new Account()
            {
                Id = 2,
                AccountType = "Savings",
                Transactions = new List<Transaction>()
            };

            if (File.Exists("transactions.csv"))
            {
                // This object knows how to read characters from a file
                var reader = new StreamReader("transactions.csv");

                // And we give that file reading object to the CSV reading object
                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                // And tell it we have no headers
                csvReader.Configuration.HasHeaderRecord = false;

                // Ask the csv reading object to get records that are `int`
                // and give them back to us as a List.
                checkingAccount.Transactions = csvReader.GetRecords<Transaction>().ToList();
                savingsAccount.Transactions = csvReader.GetRecord<Transaction>().ToList();
            }

            var userHasQuitApp = false;

            while (userHasQuitApp == false)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to First Bank of Suncoast! Please choose an option.");
                Console.WriteLine("(V)iew account balances");
                Console.WriteLine("(D)eposit funds into checking or savings accounts");
                Console.WriteLine("(W)ithdraw funds from checking or savings accounts");
                Console.WriteLine("(Q)uit the application");
                Console.WriteLine();

                var choice = PromptForString("Choice: ");

                if (choice == "D")
                    Console.WriteLine("What account would you like to deposit funds into? (C)hecking or (S)avings account.");
                var choiceOfAccount = PromptForString("Choice: ");

                if (choiceOfAccount == "C")
                {
                    var newId = Guid.NewGuid();
                    var newAccountId = 1;
                    var newAmount = PromptForDecimal("How much would you like to deposit? ");
                    var newDate = DateTime.Now;
                    var newTransaction = new Transaction

                    {
                        Id = newId,
                        AccountId = newAccountId,
                        Amount = newAmount,
                        TransactionDate = newDate,
                    };
                    checkingAccount.Transactions.Add(newTransaction);
                    Console.WriteLine($"You have deposited {newAmount} into your checking account.");

                }

                if (choiceOfAccount == "S")
                {
                    var newId = Guid.NewGuid();
                    var newAccountId = 2;
                    var newAmount = PromptForDecimal("How much would you like to deposit? ");
                    var newDate = DateTime.Now;
                    var newTransaction = new Transaction
                    {
                        Id = newId,
                        AccountId = newAccountId,
                        Amount = newAmount,
                        TransactionDate = newDate,
                    };
                    savingsAccount.Transactions.Add(newTransaction);
                    Console.WriteLine($"You have deposited {newAmount} into your savings account.");

                }

            }

            var fileWriter = new StreamWriter("transactions.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(checkingAccount.Transactions);
            csvWriter.WriteRecords(savingsAccount.Transactions);


            fileWriter.Close();

        }
    }
}

