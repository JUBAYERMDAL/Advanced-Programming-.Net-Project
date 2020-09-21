using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelia.Repository.Generic;
using travelia.Models;
using System.Collections;

namespace travelia.Repository.Admin
{
    interface IAdminRepository:IRepository<userinfo>
    {
        int userTypeCount(string type);
        int placeCount(string type);
        void updateAdminInfo(string[] adminInfo);

        IEnumerable getUserInfo(string type);
        IEnumerable getHotelInfo();
        void permittedToRestricted(string email);
        void restrictedToPermitted(string email);
        void deleteAccount(string email);
        void permitHotel(string hotelName);
        void restrictHotel(string hotelName);
        void deleteHotel(string hotelName);

        IEnumerable getTravelPlaces();

        string[] deleteTravelPlace(string travelPlaceName);

        void insertCastomerCareAccount(string[] info);
        IEnumerable getCustomerCareSalarySheet();

        void addCustCareSalary(string email,string salary);

        void updateCustSalary(string email,string salary);
        void deleteCustSalaryEntry(string email);
        IEnumerable custCareSalarySheet(string email);
        void insertCustCareSalarySheet(string email,string month,string amount);
        void deletecustCareSalarySheet(string email,string month);

        IEnumerable adminServiceCharge();

        int totalServiceCharge();

        void insertServiceCharge(string email,string month,string amount);

        void deleteServiceCharge(string id);
       
    }
}
