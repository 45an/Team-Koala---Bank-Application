namespace TeamKoalaBankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            LoggingSystem();

        }

        public static int menuIndex = 0;
        public static void MenuSystem ()
        {
            bool runMenu = true;
            string menuText = $"Welcome to Koala Bank \nPlease select an option";

            List<string> menuItems = new()
            {
                "Balance",
                "Transfer",
                "Withdraw",
                "Loan",
                "Account",
                "Logout"
            };

            while (runMenu)
            {
                string selectedMenuItems = MenuList(menuItems, menuText);
                switch (selectedMenuItems)
                {
                    case "Balance":
                        Console.WriteLine(" Balance Would start here");
                        Console.WriteLine(" Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "Transfer":
                        Console.WriteLine(" Transfer would start here");
                        Console.WriteLine(" Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "Withdraw":
                        Console.WriteLine(" Withdraw would start here");
                        Console.WriteLine(" Press any key to continue");
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
                        MenuSystem();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Pin code should be a number.\nPlease try again.");
                }
                
            }


        }

        public static string MenuList (List<string> menuItem, string menuMsg)
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
    }
} 
