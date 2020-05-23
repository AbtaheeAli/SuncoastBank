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
        }
    }
}
