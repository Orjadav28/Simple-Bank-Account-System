This is a simple console application to manage bank accounts using a class library. The application allows users to create accounts, deposit money, withdraw money, check balances, calculate interest for savings accounts, and display transaction history.

## Features

- Create new accounts (Savings and Current)
- Deposit money into an account
- Withdraw money from an account
- Check account balances
- Calculate interest for savings accounts
- Display transaction history for accounts

## Project Structure

- **Simple_Bank_Account_System**
  - `Account.cs`: Defines the base `Account` class with properties and methods for common account operations.
  - `CurrentAccount.cs`: Defines the `CurrentAccount` class, inheriting from `Account` and adding overdraft functionality.
  - `SavingsAccount.cs`: Defines the `SavingsAccount` class, inheriting from `Account` and adding interest calculation functionality.
  - `ITransaction.cs`: Defines the `ITransaction` interface for deposit and withdraw methods.
  - `Program.cs`: Contains the main program logic for the console application.
