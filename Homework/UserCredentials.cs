using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework
{
    public class UserCredentials
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Salt { get; set; }
        public int AccountNumber { get; set; }
        public int Balance { get; set; }
        public long ToAccount { get; set; }
        public long FromAccount { get; set; }
        public double HowMuch { get; set; }

        public UserCredentials()
        {

        }
    }
}