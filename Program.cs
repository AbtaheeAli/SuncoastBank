﻿using System;
using System.Collections.Generic;


namespace FirstBankOfSuncoast
{
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
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


        }
    }
}
