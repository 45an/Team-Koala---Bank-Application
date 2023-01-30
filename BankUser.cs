using System;
namespace TeamKoalaBankApp
{
	public class BankUser
	{
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string pin_code { get; set; }

        public string fullName
        {
            get
            {
                return $"{first_name} {last_name}";
            }
        }
    }
}


