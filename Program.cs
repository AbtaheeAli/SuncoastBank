using System;
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
                Console.WriteLine("Welcome to First Bank of Suncoast! Please choose an option.");
                Console.WriteLine("(V)iew account balances");
                Console.WriteLine("(D)eposit funds into checking or savings accounts");
                Console.WriteLine("(W)ithdraw funds from checking or savings accounts");
                Console.WriteLine("(Q)uit the application");

                var choice = PromptForString("Choice: ");

            }


        }
    }
}
