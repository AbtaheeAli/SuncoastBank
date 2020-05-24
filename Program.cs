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

            // var listOfTransactions = new List<Transaction>();
            // listOfTransactions.Add(checkingAccount.Transactions);

            // listOfTransactions.Add(checkingAccount.Transactions);
            // listOfTransactions.ForEach(Console.WriteLine);

            if (File.Exists("transactions.csv"))
            {
                var reader = new StreamReader("transactions.csv");

                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                checkingAccount.Transactions = csvReader.GetRecords<Transaction>().ToList();
                savingsAccount.Transactions = csvReader.GetRecords<Transaction>().ToList();
            }

            // foreach (var transaction in checkingAccount.Transactions)

            // {
            //     var orderTransactionsByTime = checkingAccount.Transactions.OrderBy(transactions => transactions.TransactionDate);
            //     var description = checkingAccount.Description();

            //     Console.WriteLine(description);
            // }
            var orderTransactionsByTime = checkingAccount.Transactions.OrderBy(transactions => transactions.TransactionDate);
            foreach (var transaction in orderTransactionsByTime)
            {
                var description = transaction.Description;
                Console.WriteLine(description);
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

                if (choice == "Q")
                {
                    userHasQuitApp = true;
                }

                if (choice == "D")
                {
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
                            Description = ($"User {newAccountId} deposited {newAmount} at {newDate} to checking account."),
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
                            Description = ($"User {newAccountId} deposited {newAmount} at {newDate} to savings account."),
                        };
                        savingsAccount.Transactions.Add(newTransaction);
                        Console.WriteLine($"You have deposited {newAmount} into your savings account.");

                    }
                }
                if (choice == "W")
                {

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

