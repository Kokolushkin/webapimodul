using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework
{
    public class User
    {
        public User()
        {

        }
        public User(string email, string password)
        {
            Username = email;
            _password = new Password(password);
        }

        public User(UserCredentials user)
        {
            Username = user.Username;
            _password = new Password(user.Password);
            Email = user.Email;
        }

        public int Id { get; set; }
        private Password _password;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password => _password.PasswordHash;
        public string Salt => _password.Salt;
        public long AccountNumber { get; set; }
        public double Balance { get; set; }
    }
}