using System.Collections.Generic;
using System.Configuration;

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
                "Transfer",
                "Withdraw",
                "Logout"
            };

            while (runMenu)
            {
                string selectedMenuItems = MenuList(menuItems, menuText);
                switch (selectedMenuItems)
                {
                    case "View Account & Balance":
                        // Console.WriteLine(" Balance Would start here");
                        Console.WriteLine($"\n View your account and balance");
                        Console.WriteLine();

                        List<BankAccounts> checksAccounts = PostgresqlConnection.ShowBankAccounts(logInUsers[0].id);

                        for (int i = 0; i < checksAccounts.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {checksAccounts[i].name} : Balance {checksAccounts[i].balance:C}");

                        }

                        //Console.WriteLine(" Press any key to continue");
                        Console.ReadKey();

                        break;
                    case "Transfer":
                        Console.WriteLine(" Transfer would start here");

                        Console.WriteLine(" Press any key to continue");
                     
                        Console.ReadKey();
                        break;
                    case "Withdraw":
                        WithdrawSystem(logInUsers[0].id);
                        Console.ReadKey();
                        break;
                    case "Loan":
                        Console.WriteLine(" Loan would start here");
                        Console.WriteLine(" Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "Account":
                        Console.WriteLine(" Account would start here");
                        Console.WriteLine(" Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "Logout":
                        menuIndex = 0;
                        runMenu = false;
                        break;
                }
            }
        }


        public static string MenuList(List<string> menuItem, string menuMsg)
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
                Console.Write("Please enter your firstname: ");
                first_name = Console.ReadLine();

                Console.Write("Please enter your lastname: ");
                last_name = Console.ReadLine();

                Console.Write("Please enter your Pin code: ");
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

            Console.Write("\nType a number please ===> ");
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

    }
}
