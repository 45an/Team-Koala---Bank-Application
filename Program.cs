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
                "Withdraw",
                "Deposit",
                "Transfer Between Account",
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
                    case "Withdraw":
                        WithdrawSystem(logInUsers[0].id);
                        Console.ReadKey();
                        break;
                    case "Deposit":
                        Deposit(logInUsers[0].id);
                        Console.ReadKey();
                        break;
                    case "Transfer Between Account":
                        TransferBetweenAccounts(logInUsers[0].id);
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
                        Console.WriteLine("⠀⠀⠀⠈⠢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡤⠋⠀⠀⠀⠀");
                        Console.WriteLine("⠀⠀⠀⠀⢨⠃⠀⢀⠀⢀⠔⡆⠀⠀⠀⠀⠻⡄⠀⠀⠀⠀⠀");
                        Console.WriteLine("⠀⠀⡎⠀⠀⠧⠬⢾⠊⠀⠀⢀⡇⠀⠀⠟⢆⠀⠀⠀⠀");
                        Console.WriteLine("⠀⠀⠀⢀⡇⠀⠀⡞⠀⠀⢣⣀⡠⠊⠀⠀⠀⢸⠈⣆⡀⠀⠀");
                        Console.WriteLine("⡠⠒⢸⠀⠀⠀⡇⡠⢤⣯⠅⠀⠀⠀⢀⡴⠃⠀⢸⠘⢤⠀");
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
            Console.WriteLine();
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
            Console.Write("Type here: ====> ")
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
                Console.WriteLine("Press enter twice to return to the main menu.");
                Console.ReadKey();
            }
        }

        static void TransferBetweenAccounts(int user_id)
        {
            Console.WriteLine("\nWhich account do you want to transfer money from?");

            List<BankAccounts> checkAccounts = PostgresqlConnection.ShowBankAccounts(user_id);

            Console.Clear();
            for (int i = 0; i < checkAccounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {checkAccounts[i].name} | Balance: {checkAccounts[i].balance:C}");
            }

            try
            {
                Console.Write("\nEnter your choice: ===> ");
                Console.WriteLine();
                string accountChoice = Console.ReadLine();

                int.TryParse(accountChoice, out int fromAccountID);
                fromAccountID -= 1;

                BankAccounts fromAccount = checkAccounts[fromAccountID];

                Console.WriteLine("\nWhich account do you want to transfer money to?");

                List<BankAccounts> checkMainAccounts = PostgresqlConnection.ShowBankAccounts(user_id);

                for (int i = 0; i < checkAccounts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {checkMainAccounts[i].name}: {checkMainAccounts[i].balance:C}");
                }

                Console.Write("Enter your choice: ===> ");
                Console.WriteLine();
                string accountChoiceOfAccount = Console.ReadLine();

                int.TryParse(accountChoiceOfAccount, out int toAccountID);
                toAccountID -= 1;

                BankAccounts toAccount = checkAccounts[toAccountID];

                Console.Write("Enter your amount: ===> ");
                Console.WriteLine();
                decimal amountInNumber = decimal.Parse(Console.ReadLine());

                if (fromAccount.balance < amountInNumber)
                {
                    Console.WriteLine("You don't have enough money in the account.");
                    Console.WriteLine("Press enter twice to return to the main menu.");
                    Console.Write("===>");
                    Console.ReadLine();

                    return;
                }
                else
                {

                    fromAccount.balance -= amountInNumber;
                    toAccount.balance += amountInNumber;
                    Console.WriteLine($"\nThe transfer of {amountInNumber:C} from {fromAccount.name} to {toAccount.name} was completed.");
                    Console.WriteLine("Press enter twice to return to the main menu.");
                    Console.ReadLine();

                    // Save the changes to the database
                    PostgresqlConnection.UpdateAccount(fromAccount.balance, fromAccount.id, fromAccount.user_id);
                    PostgresqlConnection.UpdateAccount(toAccount.balance, toAccount.id, toAccount.user_id);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine("Press enter twice to return to the main menu.");
                Console.Write("===>");
                Console.ReadLine();
            }
        }



    }
}
