using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travelia.Models;
using travelia.Repository.Generic;

namespace travelia.Repository.Traveller
{
    public class TravellerRepository : Repository<userinfo>, ITravellerRepository
    {
        traveliaEntitiesContext context;
        public TravellerRepository()
        {
            context = new traveliaEntitiesContext();
        }

        public void cancelBooking(string id)
        {
            var info = context.bookinginfoes.Where(x => x.id.ToString() == id).First();
            info.status = "cancelled";
            context.SaveChanges();
        }

        public void deleteTravellerAccount(string id)
        {
            var userinfo = context.userinfoes.Where(x => x.id.ToString() == id).First();
            var user = context.users.Where(x => x.usermail == userinfo.usermail).First();
            context.userinfoes.Remove(userinfo);
            context.users.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable getHotels(string location)
        {
            var hotels = context.hotelinfoes.Where(x=>x.location==location).ToList();
            return hotels;
        }

        public IEnumerable getMyBooking(string email)
        {
            return context.bookinginfoes.Where(x => x.travellermail == email).ToList();
        }

        public IEnumerable getTravelPlace(string division)
        {
            return context.travelplaces.Where(x=>x.division==division).ToList();
        }

        public void insertBookinginfo(string[] booking)
        {
            bookinginfo info = new bookinginfo
            {
                travellermail = booking[0],
                hotelempmail=booking[1],
                hotelname=booking[2],
                checkin=booking[3],
                checkout=booking[4],
                days=booking[5],
                roomtype=booking[6],
                totalcost=booking[7],
                status="requested"
            };

            context.bookinginfoes.Add(info);
            context.SaveChanges();
        }

        public void messageToHotel(string msgfrom, string to, string msg)
        {
            messagetohotel info = new messagetohotel
            {
                msgfrom=msgfrom,
                msgto=to,
                msg=msg
            };
            context.messagetohotels.Add(info);
            context.SaveChanges();
        }

        public void updateTravellerInfo(string[] travellerInfo)
        {
            string email = travellerInfo[0];
            var userinfo = context.userinfoes.First(x => x.usermail==email);
            var user = context.users.Where(x => x.usermail == email).First();

            userinfo.firstname = travellerInfo[1];
            userinfo.lastname = travellerInfo[2];
            userinfo.address = travellerInfo[3];
            userinfo.phoneno = travellerInfo[4];
            userinfo.status = "permitted";
            if (travellerInfo.Length == 6)
            {
                userinfo.password = travellerInfo[5];
                user.password = travellerInfo[5];
            }
            else
            {
                // userinfo.password = travellerInfo[4];

            }

            context.SaveChanges();
        }
    }
}