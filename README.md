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
    -  PostgreSQL
    -  Dapper (a Micro ORM for .NET)
    -  Visual Studio (IDE for C# development)
    
## Usage

When the application is launched, the user is prompted to enter their login credentials. If the credentials are valid,
the user is taken to the main menu where they can perform various banking operations.


# Menu Options

## The following menu options are available to the user:

    View Account & Balance: Allows the user to view their account and balance.
    
    Withdraw: Allows the user to withdraw money from their account.
    
    Deposit: Allows the user to deposit money into their account.
    
    Transfer Between Account: Allows the user to transfer money between their accounts.
    
    Logout: Logs the user out of the application.
    
    

    
    
## 💻 Code Structure

  The code is structured in the following way:
  
 

 ```sh
 
   - Program.cs: Main entry point of the application.
   
   - PostgresqlConnection.cs: Class that handles all database interactions using Dapper.
   
   - BankAccounts.cs: Model class that represents a bank account.
   
   - BankUser.cs: Model class that represents a bank user.
   
   - TransactionsModel.cs: Model class that represents a bank transaction.
   
   - App.config (which is not included in the repository for safety reasons)
   
The code includes multiple methods that handle various functionalities of the program.

The StartProgram() method is the first method that gets executed when the program starts,
 and it calls the LoggingSystem() method.

The MenuSystem(List<BankUser> logInUsers) method implements the main menu system of the application. 
The method initializes a list of menu items and uses a while loop to display the menu and receive user input. 
It uses a switch statement to execute the selected menu item's corresponding method.

The WithdrawSystem(int id) method handles the user's withdrawal from their bank account, and the Deposit(int id)
method handles the user's deposit into their account. 
The TransferBetweenAccounts(int id) method allows the user to transfer funds between two of their accounts.

The MenuList(List<string?> menuItem, string? menuMsg) method is responsible for displaying 
a list of menu items and receiving user input.
It uses a ConsoleKeyInfo object to capture the user's input, such as the arrow keys or the enter key.

The program also includes a PostgresqlConnection class that handles the connection to the PostgreSQL 
database and has methods for querying and updating data in the database using Dapper.

```

 ## 📑 BankUser Class
 
    The BankUser class represents a user of a banking application.
    
    It contains properties for the user's ID, first name, last name, and PIN code.
    
    Additionally, it includes a read-only fullName property that returns the user's 
    
    full name by concatenating their first and last names.
       
      Properties
      
     - id: An integer representing the user's ID.
     
     - first_name: A string representing the user's first name.
     
     - last_name: A string representing the user's last name.
     
     - pin_code: A string representing the user's PIN code.
     
     
  ## 📑 The BankAccounts class represents a bank account with the following properties:

     - user_id - An integer representing the ID of the user associated with the bank account.
     
     - id - An integer representing the ID of the bank account.
     
     - name - A string representing the name of the bank account.
     
     - balance - A decimal representing the current balance of the bank account.
     
     - interest_rate - A double representing the interest rate associated with the bank account.
     
     - currency_name - A string representing the name of the currency associated with the bank account.
     
     - currency_exchange_rate - A double representing the exchange rate associated with the currency of the bank account.
     
     - currency_id - An integer representing the ID of the currency associated with the bank account.
     
      - This Class is used to represent a user's bank account in our bank application.

   
