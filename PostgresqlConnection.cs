using Dapper;
using Npgsql;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace TeamKoalaBankApp
{
    class PostgresqlConnection
    {
        public static List<BankUser> OldLoadBankUsers()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {

                var output = cnn.Query<BankUser>("select * from bank_user", new DynamicParameters());
                //Console.WriteLine(output);
                return output.ToList();
            }
            // Kopplar upp mot DB:n
            // läser ut alla Users
            // Returnerar en lista av Users
        }
        public static List<BankUser> LoadBankUsers(int user_id)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {

                var output = cnn.Query<BankUser>("select * from bank_user", new DynamicParameters());
                //Console.WriteLine(output);
                return output.ToList();
            }
            // Kopplar upp mot DB:n
            // läser ut alla Users
            // Returnerar en lista av Users
        }
        public static List<BankUser> CheckLogin(string first_name, string last_name, string pin_code)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BankUser>($"SELECT * FROM bank_user WHERE first_name = '{first_name}' AND last_name = '{last_name}' AND pin_code = '{pin_code}'", new DynamicParameters());
                // Console.WriteLine(output);
                return output.ToList();
            }
            // Kopplar upp mot DB:n
            // läser ut alla Users
            // Returnerar en lista av Users
        }

        public static List<BankAccounts> GetUserAccounts(int user_id)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BankAccounts>($"SELECT bank_account.*, bank_currency.name AS currency_name, bank_currency.exchange_rate AS currency_exchange_rate FROM bank_account, bank_currency WHERE user_id = '{user_id}' AND bank_account.currency_id = bank_currency.id", new DynamicParameters());
                //Console.WriteLine(output);
                return output.ToList();
            }

        }

        public static void SaveBankUser(BankUser user)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into bank_users (first_name, last_name, pin_code) values (@first_name, @last_name, @pin_code)", user);

            }
        }

        public static void UpdateAccount(decimal amount, int id, int user_id)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE bank_account SET balance = '{amount.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}' WHERE id = '{id}' AND user_id = '{user_id}'", new DynamicParameters());
            }
        }



        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static List<BankAccounts> ShowBankAccounts(int user_id)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BankAccounts>($"SELECT * FROM bank_account WHERE user_id = '{user_id}'", new DynamicParameters());
                return output.ToList();
            }
        }


        public static bool TransferMoney(int user_id, int from_account_id, int to_account_id, decimal amount)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                string newAmount = amount.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                try
                {

                    var output = cnn.Query($@"
                    BEGIN TRANSACTION;
                    UPDATE bank_account SET balance = CASE
                       WHEN id = {from_account_id} AND balance >= '{newAmount}' THEN balance - '{newAmount}'
                       WHEN id = {to_account_id} THEN balance + '{newAmount}'
                    END
                    WHERE id IN ({from_account_id}, {to_account_id});
                    INSERT INTO bank_transaction (name, from_account_id, to_account_id, amount) VALUES ('Överföring', {from_account_id}, {to_account_id}, '{newAmount}');
                    COMMIT;
                ", new DynamicParameters());


                }
                catch (Npgsql.PostgresException e)
                {

                    Console.WriteLine(e.MessageText);
                    return false;
                }
                return true;

            }
        }
    }
}
