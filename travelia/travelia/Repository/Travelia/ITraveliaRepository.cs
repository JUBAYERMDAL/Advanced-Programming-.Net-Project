using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelia.Models;
using travelia.Repository.Generic;

namespace travelia.Repository.Travelia
{
    interface ITraveliaRepository:IRepository<userinfo>
    {
        void createNewUser(string[] info);
        int loginCheck(string email, string password);
        string[] userType(string email);
    }
}
