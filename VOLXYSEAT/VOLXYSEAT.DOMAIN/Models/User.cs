using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOLXYSEAT.DOMAIN.Core;

namespace VOLXYSEAT.DOMAIN.Models
{
    public class User : Entity
    {
        public User(string name, string email, string password, string role, string passwordConfirm)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            PasswordConfirm = passwordConfirm;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string PasswordConfirm { get; private set; }
    }
}
