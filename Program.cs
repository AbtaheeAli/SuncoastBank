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
        static void displayGreeting()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("~~~~~~~~~ Welcome to Suncoast Bank! ~~~~~~~~~  ");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();
        }

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
            displayGreeting();

            var transactionsController = new TransactionsController();
            transactionsController.LoadAllTransactions();

            transactionsController.CalculateCheckingAccountBalance();
            transactionsController.CalculateSavingsAccountBalance();
            Console.WriteLine($"Your balance in your checking account is {transactionsController.checkingAccountValue}");
            Console.WriteLine($"Your balance in your checking account is {transactionsController.savingsAccountValue}");

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

                if (choice == "V")
                {
                    Console.WriteLine();
                    Console.WriteLine("Here are the balances of your checking and savings account.");
                    Console.WriteLine();

                    transactionsController.CalculateCheckingAccountBalance();
                    transactionsController.CalculateSavingsAccountBalance();
                    Console.WriteLine($"Your balance in your checking account is {transactionsController.checkingAccountValue}");
                    Console.WriteLine($"Your balance in your checking account is {transactionsController.savingsAccountValue}");
                    Console.WriteLine("Press any key to back to the main menu.");
                    Console.ReadKey();
                }

                if (choice == "D")
                {
                    Console.WriteLine();
                    Console.WriteLine("What account would you like to deposit funds into? (C)hecking or (S)avings account.");
                    Console.WriteLine();

                    var choiceOfAccount = PromptForString("Choice: ");
                    Console.WriteLine();

                    if (choiceOfAccount == "C")
                    {
                        var newAmount = PromptForDecimal("How much would you like to deposit? ");
                        Console.WriteLine();

                        var newTransaction = new Transaction
                        {
                            Id = Guid.NewGuid(),
                            AccountId = 1,
                            Amount = newAmount,
                            AccountType = ("Checking"),
                            TransactionType = ("Deposit"),
                            TransactionDate = DateTime.Now,
                        };

                        if (newAmount <= 0)
                        {
                            Console.WriteLine("You have inputted an invalid amount.");
                            Console.WriteLine("Press any key to back to the main menu to try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            transactionsController.DepositChecking(newTransaction);
                            Console.WriteLine($"You have deposited {newAmount} into your checking account.");
                            Console.WriteLine("Press any key to back to the main menu.");
                            Console.ReadKey();
                            transactionsController.SaveAllTransactions();
                            transactionsController.CalculateCheckingAccountBalance();
                        }
                    }

                    if (choiceOfAccount == "S")
                    {

                        var newAmount = PromptForDecimal("How much would you like to deposit? ");
                        Console.WriteLine();
                        var newTransaction = new Transaction
                        {
                            Id = Guid.NewGuid(),
                            AccountId = 2,
                            Amount = newAmount,
                            AccountType = ("Savings"),
                            TransactionType = ("Deposit"),
                            TransactionDate = DateTime.Now,
                        };

                        if (newAmount <= 0)
                        {
                            Console.WriteLine("You have inputted an invalid amount.");
                            Console.WriteLine("Press any key to back to the main menu to try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            transactionsController.DepositSavings(newTransaction);
                            Console.WriteLine($"You have deposited {newAmount} into your savings account.");
                            Console.WriteLine("Press any key to back to the main menu.");
                            Console.ReadKey();
                            transactionsController.SaveAllTransactions();
                            transactionsController.CalculateSavingsAccountBalance();
                        }

                    }
                }

                if (choice == "W")
                {
                    Console.WriteLine("What account would you like to withdraw from? (C)hecking or (S)avings account.");
                    var choiceOfAccount = PromptForString("Choice: ");

                    if (choiceOfAccount == "C")
                    {
                        var newAmount = PromptForDecimal("How much would you like to withdraw? ");

                        var newTransaction = new Transaction
                        {
                            Id = Guid.NewGuid(),
                            AccountId = 1,
                            Amount = newAmount,
                            AccountType = ("Checking"),
                            TransactionType = ("Withdrawal"),
                            TransactionDate = DateTime.Now,
                        };

                        if (newAmount <= 0)
                        {
                            Console.WriteLine("You have inputted an invalid amount.");
                            Console.WriteLine("Press any key to back to the main menu to try again.");
                            Console.ReadKey();
                        }

                        if (transactionsController.checkingAccountValue < newAmount)
                        {
                            Console.WriteLine("The amount is more than what you have available in you checking account.");
                            Console.WriteLine("Press any key to back to the main menu to try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            transactionsController.WithdrawChecking(newTransaction);
                            Console.WriteLine($"You have withdrew {newAmount} from your checking account.");
                            Console.WriteLine("Press any key to back to the main menu");
                            Console.ReadKey();
                            transactionsController.SaveAllTransactions();
                            transactionsController.CalculateCheckingAccountBalance();
                        }
                    }

                    if (choiceOfAccount == "S")
                    {
                        var newAmount = PromptForDecimal("How much would you like to withdraw? ");

                        var newTransaction = new Transaction
                        {
                            Id = Guid.NewGuid(),
                            AccountId = 2,
                            Amount = newAmount,
                            AccountType = ("Savings"),
                            TransactionType = ("Withdrawal"),
                            TransactionDate = DateTime.Now,
                        };

                        if (newAmount <= 0)
                        {
                            Console.WriteLine("You have inputted an invalid amount.");
                            Console.WriteLine("Press any key to back to the main menu to try again.");
                            Console.ReadKey();
                        }

                        if (transactionsController.savingsAccountValue < newAmount)
                        {
                            Console.WriteLine("The amount,is more than what you have available in you savings account.");
                            Console.WriteLine("Press any key to back to the main menu to try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            transactionsController.WithdrawSavings(newTransaction);
                            Console.WriteLine($"You have withdrew {newAmount} from your savings account.");
                            Console.WriteLine("Press any key to back to the main menu.");
                            Console.ReadKey();
                            transactionsController.SaveAllTransactions();
                            transactionsController.CalculateSavingsAccountBalance();
                        }
                    }
                }
            }
        }
    }
}