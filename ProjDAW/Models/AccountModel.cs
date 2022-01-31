using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjDAW.Models
{
    public class AccountModel
    {
        private List<Account> accounts;

        public AccountModel()
        {
            accounts = new List<Account>()
            {
                new Account()
                {
                    Username = "acc1",
                    Password = "123",
                    Roles = new string[] {"admin"}
                },

                new Account()
                {
                    Username = "acc2",
                    Password = "123",
                    Roles = new string[] {"user"}
                },
            };
        }

        public Account find(string username)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username));
        }

        public Account login(string username, string password)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        }

    }
}
