using System.Collections.Generic;
using System.Configuration;
using Dapper;
using Npgsql;
using System.Data;
using System.Globalization;

namespace TeamKoalaBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram();

        }
        public static void StartProgram()
        {
            LoggingSystem();

        }

        public static int menuIndex = 0;
        public static void MenuSystem(List<BankUser> logInUsers)
        {
            bool runMenu = true;
            string menuText = $"Welcome to Koala Bank \nPlease select an option";

            List<string> menuItems = new()
            {
                "View Account & Balance",
                "Deposit",
                "Withdraw",
                "Logout"
            };

            while (runMenu)
            {
                string selectedMenuItems = MenuList(menuItems, menuText);
                switch (selectedMenuItems)
                {
                    case "View Account & Balance":
                        
                        Console.WriteLine($"\n View your account and balance");
                        Console.WriteLine();

                        List<BankAccounts> checksAccounts = PostgresqlConnection.ShowBankAccounts(logInUsers[0].id);

                        for (int i = 0; i < checksAccounts.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {checksAccounts[i].name} : Balance {checksAccounts[i].balance:C}");

                        }

                        
                        Console.ReadKey();

                        break;
                    case "Deposit":
                        Deposit(logInUsers[0].id);

                        break;
                    case "Withdraw":
                        WithdrawSystem(logInUsers[0].id);
                        Console.ReadKey();
                        break;
                    case "Logout":
                        Console.WriteLine($"\nThanks for using our services, Have a Nice day :)");
                        Console.WriteLine();
                        Console.WriteLine("⢀⠔⠊⠉⠑⢄⠀⠀⣀⣀⠤⠤⠤⢀⣀⠀⠀⣀⠔⠋⠉⠒⡄");
                        Console.WriteLine("⡎⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠀⠘⡄");
                        Console.WriteLine("⣧⢢⠀⠀⠀⠀⠀⠀⠀⠀⣀⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⣆⡗⠀");
                        Console.WriteLine("⠘⡇⠀⢀⠆⠀⠀⣀⠀⢰⣿⣿⣧⠀⢀⡀⠀⠀⠘⡆⠀⠈⡏⠀");
                        Console.WriteLine("⠀⠑⠤⡜⠀⠀⠈⠋⠀⢸⣿⣿⣿⠀⠈⠃⠀⠀⠀⠸⡤⠜⠀⠀");
                        Console.WriteLine("⠀⠀⠀⣇⠀⠀⠀⠀⠀⠢⣉⢏⣡⠀⠀⠀⠀⠀⠀⢠⠇⠀⠀⠀");
                        Console.WriteLine("⠀⠀⠀⠈⠢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡤⠋⠀⠀⠀⠀⠁");
                        Console.WriteLine("⠀⠀⠀⠀⢨⠃⠀⢀⠀⢀⠔⡆⠀⠀⠀⠀⠻⡄⠀⠀⠀⠀⠀");
                        Console.WriteLine("⠀⠀⡎⠀⠀⠧⠬⢾⠊⠀⠀⢀⡇⠀⠀⠟⢆⠀⠀⠀⠀");
                        Console.WriteLine("⠀⠀⠀⢀⡇⠀⠀⡞⠀⠀⢣⣀⡠⠊⠀⠀⠀⢸⠈⣆⡀⠀⠀");
                        Console.WriteLine("⡠⠒⢸⠀⠀⠀⡇⡠⢤⣯⠅⠀⠀⠀⢀⡴⠃⠀⢸⠘⢤⠀⠒");
                        Console.WriteLine("⠀⢰⠁⠀⢸⠀⠀⠀⣿⠁⠀⠙⡟⠒⠒⠉⠀⠀⠀⠀⠀⡇⡎⠀");
                        Console.WriteLine("⠀⠘⣄⠀⠸⡆⠀⠀⣿⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⢀⠟⠁⠀");
                        Console.WriteLine("⠘⠦⣀⣷⣀⡼⠽⢦⡀⠀⠀⢀⣀⣀⣀⠤⠄");
                        Console.WriteLine();
                        menuIndex = 0;
                        runMenu = false;
                        break;
                }
            }
        }


        public static string  MenuList(List<string?> menuItem, string? menuMsg)
        {


            Console.Clear();
            Console.WriteLine("");


            Console.WriteLine(menuMsg);
            Console.WriteLine("");

            for (int i = 0; i < menuItem.Count; i++)
            {
                if (i == menuIndex)
                {
                    Console.WriteLine($"[{menuItem[i]}]");
                }
                else
                {
                    Console.WriteLine($"{menuItem[i]} ");
                }
            }


            ConsoleKeyInfo ckey = Console.ReadKey();


            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (menuIndex == menuItem.Count - 1) { }
                else { menuIndex++; }
            }

            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (menuIndex <= 0) { }
                else { menuIndex--; }
            }
            //Left arrow key check
            else if (ckey.Key == ConsoleKey.LeftArrow)
            {

            }

            else if (ckey.Key == ConsoleKey.RightArrow)
            {
                return menuItem[menuIndex];
            }

            else if (ckey.Key == ConsoleKey.Enter)
            {
                return menuItem[menuIndex];
            }
            else
            {
                return "";
            }

            return "";
        }

        public static void LoggingSystem()
        {

            int maxAttempt = 3;

            string first_name, last_name, pin_code;

            while (maxAttempt > 0)
            {
                // Be användaren att ange användarnamn och personlig kod
                Console.WriteLine("---- Welcome to Koala Bank ----");
                Console.WriteLine();
                Console.Write("Please enter your Firstname: ");
                first_name = Console.ReadLine();
                

                Console.Write("Please enter your Lastname: ");
                last_name = Console.ReadLine();
                

                Console.Write("Please enter your Pincode: ");
                pin_code = Console.ReadLine();
               

                try
                {
                    int pin = int.Parse(pin_code);
                    List<BankUser> checkUsers = PostgresqlConnection.CheckLogin(first_name, last_name, pin_code);

                    if (checkUsers.Count < 1)
                    {
                        maxAttempt--;
                        Console.WriteLine("Failed loggin attempt. You have {0} chances left, Please try again", maxAttempt);
                        Console.WriteLine();

                        if (maxAttempt == 0)
                        {
                            Console.WriteLine("You have exceeded the maximum number of login attempts. Your account is logout form the system.");
                            Console.WriteLine();
                            return;
                            Environment.Exit(0);

                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Log in Sucess");
                        Console.WriteLine();
                        Console.Clear();    
                        MenuSystem(checkUsers);


                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Pin code should be a number.\nPlease try again.");
                }

            }


        }

        public static void WithdrawSystem(int user_id)
        {
            
            decimal amount;
            List<BankAccounts> checkAccounts = PostgresqlConnection.ShowBankAccounts(user_id);

            Console.Clear();
            Console.WriteLine("Which account do you wish to withdraw money from?\n");

            for (int i = 0; i < checkAccounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {checkAccounts[i].name} | Balance: {checkAccounts[i].balance:C}");
            }

            Console.Write("\nPlease select an account ===> ");
            string? accountChoice = Console.ReadLine();

            int.TryParse(accountChoice, out int accountID);
            accountID -= 1;

            Console.WriteLine("\nHow much money to withdraw from you bank account??\n");
            Console.Write("Type here: ");
            string? transfer = Console.ReadLine();
            decimal.TryParse(transfer, out amount);

            if (amount <= 0)
            {
                Console.WriteLine("Amount to witdraw cannot be a negative value."); 
            }
            else if (checkAccounts[accountID].balance < amount)
            {
                Console.WriteLine("\n\t Not allowed. You don't have enough money");
            }
            else
            {
                amount = checkAccounts[accountID].balance -= amount;
                Console.WriteLine($"\nAccount: {checkAccounts[accountID].name} New balance is : {amount}");
                PostgresqlConnection.UpdateAccount(amount, checkAccounts[accountID].id, user_id);
            }
        }

        public static void Deposit(int user_id)

        {
            decimal amount;
            List<BankAccounts> checkAccounts = PostgresqlConnection.ShowBankAccounts(user_id);

            Console.Clear();
            Console.WriteLine("To which account would to like to deposit the money?\n");

            for (int i = 0; i < checkAccounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {checkAccounts[i].name} | Balance: {checkAccounts[i].balance:C}");
            }
            Console.Write("\nPlease select an account ===> ");
            string? accountChoice = Console.ReadLine();
            int.TryParse(accountChoice, out int accountID);
            accountID -= 1;

            Console.WriteLine("\nHow much money would you like to deposit to your bank account?\n");
            Console.Write("Type here: ");
            string? deposit = Console.ReadLine();
            decimal.TryParse(deposit, out amount);


            if (amount <= 0)
            {
                Console.WriteLine("Amount to deposit cannot be a negative value.");
            }

            else
            {
                amount = checkAccounts[accountID].balance += amount;
                Console.WriteLine($"\nAccount: {checkAccounts[accountID].name} New balance is : {amount}");
                PostgresqlConnection.UpdateAccount(amount, checkAccounts[accountID].id, user_id);
            }
        }
       
        /*

        public static void Transfer(int user_Id)
        {
            menuIndex = 0;

            //Declatation
            List<BankAccounts> checkaccounts = PostgresqlConnection.GetUserAccounts(user_Id);
            List<string> menuItems = new List<string>();
            bool runMenu = true;
            bool runMenu2 = true;
            string? senderAccountName, reciverAccountName, input;
            int senderAccountId, reciverAccountId, senderAccountPos, reciverAccountPos;
            decimal senderBalance, reciverBalance;
            string menuMsg = " Please select an account to transfer from\n ";
            string menuMsg2 = "\n Please select a reciver account";

            //Create menu Items
            for (int i = 0; i < checkaccounts.Count; i++)
            {
                menuItems.Add(checkaccounts[i].name);
            }
            menuItems.Add("Exit");

            //Menu Start
            while (runMenu)
            {
                int selectedItems = Int32.Parse( MenuList(menuItems, menuMsg));

                //Exit casew
                if (selectedItems == menuItems.Count - 1)
                {
                    runMenu = false;
                }
                //select account case
                else if (selectedItems <= menuItems.Count - 1)
                {
                    Console.Clear();
                    senderAccountId = checkaccounts[selectedItems].id;
                    senderAccountName = checkaccounts[selectedItems].name;
                    senderBalance = checkaccounts[selectedItems].balance;
                    senderAccountPos = selectedItems;
                    Console.WriteLine($"\n {checkaccounts[selectedItems].name} account was selected");
                    menuMsg2 = menuMsg2 + $"\n Sender account: {checkaccounts[selectedItems].name}";
                    Console.ReadKey();
                    runMenu2 = true;
                    menuIndex = 0;

                    //Submenu Start
                    while (runMenu2)
                    {
                        selectedItems = Int32.Parse(MenuList(menuItems, menuMsg));
                        reciverAccountName = "";
                        //Exit case
                        if (selectedItems == menuItems.Count - 1)
                        {
                            runMenu2 = false;
                        }
                        else if (selectedItems <= menuItems.Count - 1)
                        {

                            Console.Clear();
                            reciverAccountId = checkaccounts[selectedItems].id;
                            reciverAccountName = checkaccounts[selectedItems].name;
                            reciverAccountPos = selectedItems;

                            //Same account was selected
                            if (senderAccountName == reciverAccountName)
                            {
                                Console.Clear();
                                Console.WriteLine($"\n Can not select the same account");
                                Console.WriteLine($" Press any key to continue");
                                Console.ReadKey();
                            }
                            //Select reciver account
                            else
                            {
                                reciverBalance = checkaccounts[selectedItems].balance;

                                Console.WriteLine($"\n {checkaccounts[selectedItems].name} account was selected");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine($"\n Sender account: {senderAccountName}: {senderBalance}");
                                Console.WriteLine($" Reciver account: {reciverAccountName}: {reciverBalance}");
                                Console.Write($"\n Enter amount you wish to transfer: ");
                                input = Console.ReadLine();


                                decimal.TryParse(input, out decimal transferAmount);
                                //Transfer amount is negative
                                if (transferAmount <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\n Amount can not be negative");
                                    Console.WriteLine($" Press any key to continue");
                                    Console.ReadKey();
                                    runMenu = false;
                                    runMenu2 = false;
                                }
                                //Transfer amount larger than balance
                                else if (transferAmount > senderBalance)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\n Transfer amount exceeds account balance");
                                    Console.WriteLine($" Press any key to continue");
                                    Console.ReadKey();
                                    runMenu = false;
                                    runMenu2 = false;
                                }
                                //Transfer Start
                                else
                                {

                                    //check currencies
                                   if (checkaccounts[senderAccountPos].currency_id != checkaccounts[reciverAccountPos].currency_id)
                                    {
                                        //transaction between different currencies
                                        transferAmount = currency_exchange(transferAmount, senderAccountPos, reciverAccountPos, checkaccounts);
                                        PostgresqlConnection.Transfer(user_Id, senderAccountId, reciverAccountId, reciverBalance, transferAmount);
                                        Console.WriteLine($"\n {Math.Truncate(transferAmount * 100) / 100} was transfered to {reciverAccountName}");
                                        Console.WriteLine($"\n Press any key to continue");
                                        Console.ReadKey();

                                        runMenu = false;
                                        runMenu2 = false;
                                    }
                                    //transaction between same currency
                                    else
                                    {
                                        //execute transaction
                                        PostgresqlConnection.Transfer(user_Id, senderAccountId, reciverAccountId, reciverBalance, transferAmount);

                                        Console.WriteLine($"\n {Math.Truncate(transferAmount * 100) / 100} was transfered to {reciverAccountName}");
                                        Console.WriteLine($"\n Press any key to continue");
                                        Console.ReadKey();
                                        runMenu = false;
                                        runMenu2 = false;
                                    }
                                }

                            }
                        }

                    }

                }

            }
            menuIndex = 0;
        }
        */






    }
}
