using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using travelia.Models;
using travelia.Repository.Generic;

namespace travelia.Repository.guider
{
    interface IGuiderRepository:IRepository<userinfo>
    {
        void updateGuiderInfo(string[] guiderInfo);
        IEnumerable getTravelPlace(string email);

        void deleteMyTravelPlace(string id);

        travelplace getTravelPlacebyId(string id);
        void updateTravelPlace(string[] info);
        string deleteTravelPlace(string id);

        void updatePicture(string[] info, HttpPostedFileBase file);

        void insertTravelPlace(string[] info, HttpPostedFileBase file);

        IEnumerable getTravelPlaceByDivision(string division);
    }
}
