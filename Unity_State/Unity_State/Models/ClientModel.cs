using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unity_State.Models
{
    public class ClientModel
    {
        public enum Sex
        {
            Male, Famale
        }
        public string login;
        public string password;
        public Sex sex;
        public string number;
        public string email;

    }
}
