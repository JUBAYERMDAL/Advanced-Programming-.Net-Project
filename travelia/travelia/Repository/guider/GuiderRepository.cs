using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using travelia.Models;
using travelia.Repository.Generic;

namespace travelia.Repository.guider
{
    public class GuiderRepository:Repository<userinfo>,IGuiderRepository
    {
        traveliaEntitiesContext context;
        public GuiderRepository()
        {
            context = new traveliaEntitiesContext();
        }

        public void deleteMyTravelPlace(string id)
        {
            int placeid = Int32.Parse(id);
            var place = context.travelplaces.Where(x => x.id == placeid).First();
            context.travelplaces.Remove(place);
            context.SaveChanges();
        }



        public string deleteTravelPlace(string id)
        {
            int ids = Int32.Parse(id);
            var info = context.travelplaces.Where(x => x.id == ids).First();
            string imagepath = info.division + "/" + info.pictures;
            return imagepath;
        }

        public IEnumerable getTravelPlace(string email)
        {
            return context.travelplaces.Where(x => x.travelguidermail == email).ToList();

        }

        public IEnumerable getTravelPlaceByDivision(string division)
        {
            return context.travelplaces.Where(x => x.division == division).ToList();
        }

        public travelplace getTravelPlacebyId(string id)
        {
            int ids = Int32.Parse(id);
            var place = context.travelplaces.Where(x => x.id == ids).First();
            //travelplace trvplace = place as travelplace;
            return place;
        }

        public void insertTravelPlace(string[] info, HttpPostedFileBase file)
        {
            travelplace place = new travelplace
            {
                travelplace1=info[0],
                division=info[1],
                location=info[2],
                description=info[3],
                pictures=info[0],
                travelguidermail=info[4],
                status="pending"
            };
            string image = Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/images/travelplace/" + info[1] + "/"), info[0] + ".jpg");
            file.SaveAs(image);
            context.travelplaces.Add(place);
            context.SaveChanges();

        }

        public void updateGuiderInfo(string[] guiderInfo)
        {
            string email = guiderInfo[0];
            var userinfo = context.userinfoes.First(x => x.usermail == email);
            var user = context.users.Where(x => x.usermail == email).First();

            userinfo.firstname = guiderInfo[1];
            userinfo.lastname = guiderInfo[2];
            userinfo.address = guiderInfo[3];
            userinfo.phoneno = guiderInfo[4];
            userinfo.status = "permitted";
            if (guiderInfo.Length == 6)
            {
                userinfo.password = guiderInfo[5];
                user.password = guiderInfo[5];
            }
            else
            {
                // userinfo.password = guiderInfo[4];

            }

            context.SaveChanges();
        }

        public void updatePicture(string[] info, HttpPostedFileBase file)
        {
            string ids = info[0];
            var place = context.travelplaces.Where(x => x.id.ToString() == ids).First();
            place.pictures = info[1];
            string image = Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/images/travelplace/"+place.division+"/"), info[1] + ".jpg");
            file.SaveAs(image);
            context.SaveChanges();
        }

        public void updateTravelPlace(string[] info)
        {
            string ids = info[0];
            var place = context.travelplaces.Where(x => x.id.ToString() == ids).First();
            place.travelplace1 = info[1];
            place.division = info[2];
            place.location = info[3];
            place.description = info[4];

            context.SaveChanges();
        }
    }
}