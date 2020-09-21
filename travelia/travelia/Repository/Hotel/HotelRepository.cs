using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using travelia.Models;
using travelia.Repository.Generic;

namespace travelia.Repository.Hotel
{
    public class HotelRepository:Repository<userinfo>,IHotelRepository
    {
        traveliaEntitiesContext context;
        public HotelRepository()
        {
            context = new traveliaEntitiesContext();
        }

        public void deleteHotelinfo(string email)
        {
            var count = context.hotelinfoes.Where(x => x.hotelempmail == email).ToList();
            if (count.Count > 0)
            {
            var info = context.hotelinfoes.Where(x => x.hotelempmail == email).First();
                
            context.hotelinfoes.Remove(info);
            
            context.SaveChanges();
            }
            

            
        }

        public string deleteImage(string email)
        {
            var info = context.hotelinfoes.Where(x=>x.hotelempmail==email).ToList();
            if (info.Count > 0)
            {
                var image = context.hotelinfoes.First(x => x.hotelempmail == email);
                return image.pictures;
            }
            else
            {
                return "";
            }
        }

        public IEnumerable getBookingInfo(string email)
        {
            return context.bookinginfoes.Where(x => x.hotelempmail == email).ToList();

        }

        public IEnumerable gethotel(string email)
        {
            var info = context.hotelinfoes.Where(x => x.hotelempmail == email).ToList();
            return info;
        }

        public hotelinfo getHotelInfo(string email)
        {
            var info = context.hotelinfoes.Where(x=>x.hotelempmail==email).First();
            return info;
        }

        public IEnumerable getTravelPlaces()
        {
            return context.travelplaces.ToList();
        }

        public void insertHotel(string[] myhotelinfo,HttpPostedFileBase file)
        {
            deleteHotelinfo(myhotelinfo[0]);
            string types = "single bed room-bdt " + myhotelinfo[5] + ", double bed room-bdt " + myhotelinfo[6] + ", suit room-bdt " + myhotelinfo[7] + "";

            hotelinfo info = new hotelinfo
            {
                hotelempmail=myhotelinfo[0],
                hotelname=myhotelinfo[1],
                division=myhotelinfo[2],
                location=myhotelinfo[3],
                totalroom=myhotelinfo[4],
                roomtypes=types,
                description=myhotelinfo[8],
                pictures=myhotelinfo[9],
                status="permitted"
            };
            myhotelinfo[9] = Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/images/hotel/"),myhotelinfo[9]+".jpg");
            file.SaveAs(myhotelinfo[9]);
            context.hotelinfoes.Add(info);
            context.SaveChanges();
        }

        public void updateHotelEmpInfo(string[] hotelEmpInfo)
        {
            string email = hotelEmpInfo[0];
            var userinfo = context.userinfoes.First(x => x.usermail ==email );
            var user = context.users.Where(x => x.usermail == email).First();

            userinfo.firstname = hotelEmpInfo[1];
            userinfo.lastname = hotelEmpInfo[2];
            userinfo.address = hotelEmpInfo[3];
            userinfo.phoneno = hotelEmpInfo[4];
            userinfo.status = "permitted";
            if (hotelEmpInfo.Length == 6)
            {
                userinfo.password = hotelEmpInfo[5];
                user.password = hotelEmpInfo[5];
            }
            else
            {
                // userinfo.password = adminInfo[4];

            }

            context.SaveChanges();
        }

        public void updateHotelinfo(string email,string[] info)
        {
            var infos = context.hotelinfoes.Where(x => x.hotelempmail == email).First();
            string price = "single bed room-bdt " + info[2] + ", double bed room-bdt " + info[3] + ", suit room-bdt " + info[4] + "";
            infos.hotelname = info[0];
            infos.totalroom = info[1];
            infos.roomtypes = price;

            context.SaveChanges();
            
        }
















    }
}