# Team-Koala---Bank-Application

## Introduction
This is a console-based banking application built using C# programming language and PostgreSQL as the database management system. The application allows bank customers to manage their accounts and perform basic banking operations such as view account and balance, withdraw, deposit, transfer between accounts, and logout. With PostgreSQL, the application can securely store and retrieve customer account information and transaction records. The application also features robust data handling and data integrity features, ensuring that customer data is accurate and consistent.

## Requirements

To run the application, the following requirements must be met:

    - Microsoft Visual Studio IDE.
    
    - PostgreSQL installed on the system.
    
 ## ⚙️ Installation

To install and run the application, follow the steps below:

    1. Clone the repository to your local machine.
    
    2. Open the solution in Visual Studio.
    
    3. Open the PostgresqlConnection.cs file and modify the PostgreSQL
    
       connection string to match your PostgreSQL server credentials.
       
    4. Build and run the application in Visual Studio.
    
    
  # 🛠️ Tools
    
    - C# programming language
    - .NET Framework
    -  SQL
    -  Dapper (a Micro ORM for .NET)
    -  Visual Studio (IDE for C# development)
    
## Usage

When the application is launched, the user is prompted to enter their login credentials. If the credentials are valid, the user is taken to the main menu where they can perform various banking operations.
Menu Options

## The following menu options are available to the user:

    View Account & Balance: Allows the user to view their account and balance.
    
    Withdraw: Allows the user to withdraw money from their account.
    
    Deposit: Allows the user to deposit money into their account.
    
    Transfer Between Account: Allows the user to transfer money between their accounts.
    
    Logout: Logs the user out of the application.
    
    

    
    
## 💻 Code Structure

  The code is structured in the following way:

 ```sh

The code includes multiple methods that handle various functionalities of the program.

The StartProgram() method is the first method that gets executed when the program starts, and it calls the LoggingSystem() method.

The MenuSystem(List<BankUser> logInUsers) method implements the main menu system of the application. 
The method initializes a list of menu items and uses a while loop to display the menu and receive user input. 
It uses a switch statement to execute the selected menu item's corresponding method.

The WithdrawSystem(int id) method handles the user's withdrawal from their bank account, and the Deposit(int id)
method handles the user's deposit into their account. 
The TransferBetweenAccounts(int id) method allows the user to transfer funds between two of their accounts.

The MenuList(List<string?> menuItem, string? menuMsg) method is responsible for displaying a list of menu items and receiving user input.
It uses a ConsoleKeyInfo object to capture the user's input, such as the arrow keys or the enter key.

The program also includes a PostgresqlConnection class that handles the connection to the PostgreSQL 
database and has methods for querying and updating data in the database using Dapper.

```

 ## 📑 BankUser Class
 
    The BankUser class represents a user of a banking application. It contains properties for the user's ID, first name, last name, and PIN code. Additionally, it includes a read-only fullName property that returns the user's full name by concatenating their first and last names.
       
      Properties
      
     - id: An integer representing the user's ID.
     
     - first_name: A string representing the user's first name.
     
     - last_name: A string representing the user's last name.
     
     - pin_code: A string representing the user's PIN code.
     
     
  ## 📑 The BankAccounts class represents a bank account with the following properties:

     user_id - An integer representing the ID of the user associated with the bank account.
     
     id - An integer representing the ID of the bank account.
     
     name - A string representing the name of the bank account.
     
     balance - A decimal representing the current balance of the bank account.
     
     interest_rate - A double representing the interest rate associated with the bank account.
     
     currency_name - A string representing the name of the currency associated with the bank account.
     
     currency_exchange_rate - A double representing the exchange rate associated with the currency of the bank account.
     
     currency_id - An integer representing the ID of the currency associated with the bank account.
     
     This class can be used to represent the user's bank account in a banking application.
     
  ## TransactionsModel
   ```sh
   
 TransactionsModel is a class that defines a transaction with properties such as id, name, from_account_id, to_account_id, and amount.
 It also contains a method called GetSignedAmount(), which takes an account_id as a parameter and returns a string representation of the transaction amount with a negative sign if the account belongs to from_account_id.
      
 Properties
  
   id
  - Type: int
   Description: The unique identifier for the transaction.
   
   name
   - Type: string
   Description: The name of the transaction.
   
   from_account_id
   - Type: int
   Description: The identifier for the account from which the transaction amount is being deducted.
   
   to_account_id
   - Type: int
   Description: The identifier for the account to which the transaction amount is being added.
   
   amount
   - Type: decimal
   Description: The amount of the transaction.
  
```

## 🐘 PostgresqlConnection

### Database Structure
    The following tables are used in this application:

    - bank_user: Contains information about bank users.
    - bank_account: Contains information about bank accounts, including the user ID, balance, and currency.
    - bank_currency: Contains information about currencies, including the name and exchange rate.
    - bank_transaction: Contains information about bank transactions, including the name, source account ID, destination account ID, and amount.
    
### Database Interactions
    The PostgresqlConnection class contains several methods for interacting with the database, including:

    - OldLoadBankUsers(): Returns a list of all bank users.
    - GetTransactionByAccountId(int account_id): Returns a list of transactions for a given account ID.
    - LoadBankUsers(int user_id): Returns a list of bank users with a given user ID.
    - CheckLogin(string first_name, string last_name, string pin_code): Returns a list of bank users that match a given first name, last name, and PIN code.
    - GetUserAccounts(int user_id): Returns a list of bank accounts for a given user ID.
    - SaveBankUser(BankUser user): Inserts a new bank user into the database.
    - UpdateAccount(decimal amount, int id, int user_id): Updates the balance of a bank account with a given ID and user ID.
    - ShowBankAccounts(int user_id): Returns a list of bank accounts for a given user ID.
    - TransferMoney(int user_id, int from_account_id, int to_account_id, decimal amount): Transfers money between two bank accounts.
    - MakeDeposit(int account_id, decimal amount): Makes a deposit to a bank account.

   
