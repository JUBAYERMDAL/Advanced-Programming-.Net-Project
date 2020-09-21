using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelia.Models;
using travelia.Repository.Generic;

namespace travelia.Repository.Traveller
{
    interface ITravellerRepository:IRepository<userinfo>
    {
        void updateTravellerInfo(string[] travellerInfo);

        void deleteTravellerAccount(string id);
        IEnumerable getTravelPlace(string division);
        IEnumerable getHotels(string location);

        void insertBookinginfo(string[] booking);

        IEnumerable getMyBooking(string email);
        void messageToHotel(string msgfrom,string to,string msg);
        void cancelBooking(string id);
    }
}
