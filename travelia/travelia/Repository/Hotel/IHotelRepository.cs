using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using travelia.Models;
using travelia.Repository.Generic;

namespace travelia.Repository.Hotel
{
    interface IHotelRepository:IRepository<userinfo>
    {
        hotelinfo getHotelInfo(string email);

        IEnumerable gethotel(string email);

        void deleteHotelinfo(string email);

        void updateHotelinfo(string email,string[] info);
        void updateHotelEmpInfo(string[] hotelEmpInfo);

        IEnumerable getTravelPlaces();

        void insertHotel(string[] hotelinfo, HttpPostedFileBase file);

        string deleteImage(string email);

        IEnumerable getBookingInfo(string email);
    }
}
