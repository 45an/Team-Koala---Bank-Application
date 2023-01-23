using System;
namespace TeamKoalaBankApp
{
	public class BankUser
	{
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string pinCode { get; set; }

        public string fullName
        {
            get
            {
                return $"{firstName} {lastName}";
            }
        }
    }
}


