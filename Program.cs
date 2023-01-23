namespace TeamKoalaBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankUser> users = PostgresqlConnection.LoadBankUsers();
            Console.WriteLine("users length: {0}", users.Count);

            foreach (BankUser user in users)
            {
                Console.WriteLine(user.firstName);
            }
        }
        static int menuIndex = 0;
        static void MenuSystem()
        {
            bool runMenu = true;
            string menuText = " Welcome to Koala Credit\n Please select an option";

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
                string selectedMenuItems = (menuText);
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
    }
}
