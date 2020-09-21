using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travelia.Repository.Generic;
using travelia.Models;

namespace travelia.Repository.Travelia
{
    public class TraveliaRepository : Repository<userinfo>, ITraveliaRepository
    {
        traveliaEntitiesContext context;
        public TraveliaRepository()
        {
            context = new traveliaEntitiesContext();
        }
        public void createNewUser(string[] info)
        {
            userinfo newuserinfo = new userinfo
            {
                usermail= info[0],
                firstname= info[1],
                lastname= info[2],
                address= info[3],
                phoneno= info[4],
                password= info[5],
                usertype= info[6]
            };
            context.userinfoes.Add(newuserinfo);
            user newuser = new user
            {
                usermail=info[0],
                password=info[5],
                usertype=info[6]
            };
            context.users.Add(newuser);

            context.SaveChanges();
        }

        public int loginCheck(string email, string password)
        {
            var list = context.users.Where(x => x.usermail == email && x.password == password).ToList();

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
            var type = context.users.First(x => x.usermail == email);
            string[] info = { type.usermail, type.usertype };
            return info;
        }










    }
}