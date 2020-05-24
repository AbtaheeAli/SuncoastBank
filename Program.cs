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
                var reader = new StreamReader("transactions.csv");

                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                var allTransactions = csvReader.GetRecords<Transaction>();
                // savingsAccount.Transactions = csvReader.GetRecords<Transaction>().ToList();
                var checkingTransaction = allTransactions.Where(transactions => transactions.AccountId == 1).ToList();
                var savingsTransaction = allTransactions.Where(transactions => transactions.AccountId == 2).ToList();
                checkingAccount.Transactions = checkingTransaction;
                savingsAccount.Transactions = savingsTransaction;
            }


            var orderCheckingAccountValueByTime = checkingAccount.Transactions.OrderBy(transactions => transactions.TransactionDate);
            foreach (var transaction in orderCheckingAccountValueByTime)
            {
                var description = transaction.Description;
                Console.WriteLine(description);
            }

            var orderSavingsAccountValueByTime = savingsAccount.Transactions.OrderBy(transactions => transactions.TransactionDate);
            foreach (var transaction in orderSavingsAccountValueByTime)
            {
                var description = transaction.Description;
                Console.WriteLine(description);
            }
            var checkingAccountValue = new List<decimal>();
            var savingsAccountValue = new List<decimal>();

            foreach (var transaction in orderCheckingAccountValueByTime)
            {
                checkingAccountValue.Add(transaction.Amount);
            }

            foreach (var transaction in orderSavingsAccountValueByTime)
            {
                savingsAccountValue.Add(transaction.Amount);
            }

            var totalValueForCheckingAccount = checkingAccountValue.Sum();
            Console.WriteLine($"Your current balance of your checking account is {totalValueForCheckingAccount}");

            var totalValueForSavingsAccount = savingsAccountValue.Sum();
            Console.WriteLine($"Your current balance of your savings account is {totalValueForSavingsAccount}");


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
                        if (newAmount <= 0)
                        {
                            Console.WriteLine("You have inputted an invalid amount. Returning to main menu and please try again.");
                        }
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
                    Console.WriteLine("What account would you like to withdraw from? (C)hecking or (S)avings account.");
                    var choiceOfAccount = PromptForString("Choice: ");

                    if (choiceOfAccount == "C")
                    {
                        var newId = Guid.NewGuid();
                        var newAccountId = 1;
                        var newAmount = PromptForDecimal("How much would you like to withdraw? ");
                        var newDate = DateTime.Now;
                        var newTransaction = new Transaction

                        {
                            Id = newId,
                            AccountId = newAccountId,
                            Amount = newAmount * -1,
                            TransactionDate = newDate,
                            Description = ($"User {newAccountId} withdrew {newAmount} at {newDate} to checking account."),
                        };

                        checkingAccount.Transactions.Add(newTransaction);
                        Console.WriteLine($"You have withdrew {newAmount} from your checking account.");
                    }

                    if (choiceOfAccount == "S")
                    {
                        var newId = Guid.NewGuid();
                        var newAccountId = 2;
                        var newAmount = PromptForDecimal("How much would you like to withdraw? ");
                        var newDate = DateTime.Now;
                        var newTransaction = new Transaction

                        {
                            Id = newId,
                            AccountId = newAccountId,
                            Amount = newAmount * -1,
                            TransactionDate = newDate,
                            Description = ($"User {newAccountId} withdrew {newAmount} at {newDate} from savings account."),
                        };
                        savingsAccount.Transactions.Add(newTransaction);
                        Console.WriteLine($"You have withdrew {newAmount} from your savings account.");
                    }
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

