﻿using System;
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
            var transactionsController = new TransactionsController();
            transactionsController.LoadAllTransactions();

            // var checkingAccount = new Account()
            // {
            //     Id = 1,
            //     AccountType = "Checking",
            //     Transactions = new List<Transaction>(),
            //     // Value = transactionsController.CheckingAccountValues(),
            // };

            // var savingsAccount = new Account()
            // {
            //     Id = 2,
            //     AccountType = "Savings",
            //     Transactions = new List<Transaction>()
            // };

            transactionsController.RecallTransactionsByTime();


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
                        };
                        if (newAmount <= 0)
                        {
                            Console.WriteLine("You have inputted an invalid amount. Returning to main menu and please try again.");
                        }
                        transactionsController.DepositChecking(newTransaction);
                        Console.WriteLine($"You have deposited {newAmount} into your checking account.");
                        transactionsController.SaveAllTransactions();

                    }

                    if (choiceOfAccount == "S")
                    {


                        var newAmount = PromptForDecimal("How much would you like to deposit? ");

                        var newTransaction = new Transaction
                        {
                            Id = Guid.NewGuid(),
                            AccountId = 2,
                            Amount = newAmount,
                            TransactionDate = DateTime.Now,
                            // Description = ($"User {newAccountId} deposited {newAmount} at {newDate} to savings account."),
                        };
                        transactionsController.DepositSavings(newTransaction);
                        Console.WriteLine($"You have deposited {newAmount} into your savings account.");
                        transactionsController.SaveAllTransactions();

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
                        };

                        transactionsController.WithdrawChecking(newTransaction);
                        Console.WriteLine($"You have withdrew {newAmount} from your checking account.");
                        transactionsController.SaveAllTransactions();
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

                        };
                        transactionsController.WithdrawSavings(newTransaction);
                        Console.WriteLine($"You have withdrew {newAmount} from your savings account.");
                        transactionsController.SaveAllTransactions();
                    }
                }


            }







        }
    }
}

