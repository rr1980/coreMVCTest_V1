using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace Services
{
    public class LoginService : ILoginService
    {
        public bool Auth(string username, string password)
        {
            if ((username == "rr1980" || username == "Oxi") && password == "12003")
            {
                return true;
            }

            return false;
        }
    }
}
