using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travelia.Models;

namespace travelia.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        traveliaEntitiesContext context;
        public LoginRepository()
        {
            context = new traveliaEntitiesContext();
        }
        public int loginCheck(string email, string password)
        {
            var list = context.users.Where(x=>x.usermail==email && x.password==password).ToList();

            if (list.Count == 1)
            {
                var loginid = context.userinfoes.Where(x => x.usermail == email).First();
                int id = loginid.id;
                return id;
            }
            else
            {
                return 0;
            }
        }

        public string[] userType(string email)
        {
            var type = context.users.First(x=>x.usermail==email);
            string[] info = { type.usermail, type.usertype };
            return info;
        }
    }
}