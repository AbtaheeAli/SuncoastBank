# SuncoastBank

![Kapture 2020-07-02 at 16 59 04](https://user-images.githubusercontent.com/62678918/86408667-676b9f00-bc85-11ea-86c0-37b7b9f941c2.gif)

Languages and technologies used: C# & CSV

I created a personal bank account manager. This application allows the user to track both a savings and checking account total by performing transactions, such as withdrawals, deposits, and transfers. The application also saves any information inputted by the user in a CSV file.

Details about the Application:

- At start-up, the application loads past transactions from the CSV file
- The balances in savings and checking account are displayed when the program first starts
- The program will not allow the user to withdraw more money than allowed. That is, the user cannot allow the accounts to go negative
- When user is prompted for an amount to deposit or withdraw, the amount must be positive

After balances have been displayed, the application displays a menu:

- View account balances
- Deposit funds into checking or savings account
- Withdraw funds into checking or savings account
- Quit the application
