using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelia.Repository.Login
{
    interface ILoginRepository
    {
        int loginCheck(string email, string password);
        string[] userType(string email);
    }
}
