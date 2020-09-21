using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travelia.Models;
using travelia.Repository.Generic;

namespace travelia.Repository.Admin
{
    public class AdminRepository :Repository<userinfo>,IAdminRepository
    {
        traveliaEntitiesContext context;
        public AdminRepository()
        {
            context = new traveliaEntitiesContext();
        }

        public void addCustCareSalary(string email, string salary)
        {
            customercaresalary custSalary = new customercaresalary
            {
                custcaremail = email,
                currentsalary = salary
            };
            context.customercaresalaries.Add(custSalary);
            context.SaveChanges();
        }

        public IEnumerable adminServiceCharge()
        {
                        
            return context.servicecharges.ToList();
        }

        public IEnumerable custCareSalarySheet(string email)
        {
            return context.salarysheets.Where(x => x.custcaremail == email).ToList();
        }

        public void deleteAccount(string email)
        {
            var userinfo = context.userinfoes.Where(x=>x.usermail==email).First();
            context.userinfoes.Remove(userinfo);
            context.SaveChanges();
        }

        public void deletecustCareSalarySheet(string email, string month)
        {
            var sheet = context.salarysheets.Where(x=>x.custcaremail==email && x.paidmonth==month).First();
            context.salarysheets.Remove(sheet);
            context.SaveChanges();
        }

        public void deleteCustSalaryEntry(string email)
        {
            var custSalaryEntry = context.customercaresalaries.Where(x=>x.custcaremail==email).First();
            context.customercaresalaries.Remove(custSalaryEntry);
            context.SaveChanges();
        }

        public void deleteHotel(string hotelName)
        {
            var hotelinfo = context.hotelinfoes.Where(x => x.hotelname == hotelName).First();
            context.hotelinfoes.Remove(hotelinfo);
            context.SaveChanges();
        }

        public void deleteServiceCharge(string id)
        {
            var service = context.servicecharges.Where(x=>x.id.ToString()==id).First();
            context.servicecharges.Remove(service);
            context.SaveChanges();
        }

        public string[] deleteTravelPlace(string travelPlaceName)
        {
            var travelplace = context.travelplaces.Where(x=>x.travelplace1==travelPlaceName).First();
            context.travelplaces.Remove(travelplace);
            context.SaveChanges();
           // string[] picture = { travelplace.division, travelplace.pictures };
            return new string[] {travelplace.division,travelplace.pictures };
        }

        public IEnumerable getCustomerCareSalarySheet()
        {
            return context.customercaresalaries.ToList();
        }

        public IEnumerable getHotelInfo()
        {
            return context.hotelinfoes.ToList();
        }

        public IEnumerable getTravelPlaces()
        {
            return context.travelplaces.ToList();
        }

        public IEnumerable getUserInfo(string type)
        {
            var userinfos = context.userinfoes.Where(x=>x.usertype==type);
            return userinfos.ToList();
        }

        public void insertCastomerCareAccount(string[] info)
        {
            userinfo customerCareInfo = new userinfo
            {
                firstname = info[0],
                lastname = info[1],
                usermail = info[2],
                password = info[3],
                usertype = info[4],
                address = info[5],
                phoneno = info[6],
                status = info[7]

            };
            user userinfo = new user
            {
                usermail=info[2],
                password=info[3],
                usertype=info[4]
                
            };
            context.userinfoes.Add(customerCareInfo);
            context.users.Add(userinfo);
            context.SaveChanges();
        }

        public void insertCustCareSalarySheet(string email, string month, string amount)
        {
            salarysheet sheet = new salarysheet
            {
                custcaremail = email,
                salarypaid = amount,
                paidmonth = month
            };
            context.salarysheets.Add(sheet);
            context.SaveChanges();
        }

        public void insertServiceCharge(string email, string month, string amount)
        {
            servicecharge service = new servicecharge
            {
                usermail = email,
                paidmonth = month,
                amount = amount
            };

            context.servicecharges.Add(service);
            context.SaveChanges();
        }

        public void permitHotel(string hotelName)
        {
            var hotelinfo = context.hotelinfoes.Where(x => x.hotelname == hotelName).First();
            hotelinfo.status = "permitted";
            context.SaveChanges();
        }

        public void permittedToRestricted(string email)
        {
            var userinfo = context.userinfoes.Where(x => x.usermail == email).First();
            userinfo.status = "restricted";
            context.SaveChanges();
        }

        public int placeCount(string place)
        {
            int count = context.travelplaces.Where(x=>x.division==place).Count();
            return count;
        }

        public void restrictedToPermitted(string email)
        {
            var userinfo = context.userinfoes.Where(x => x.usermail == email).First();
            userinfo.status = "permitted";
            context.SaveChanges();
        }

        public void restrictHotel(string hotelName)
        {
            var hotelinfo = context.hotelinfoes.Where(x=>x.hotelname==hotelName).First();
            hotelinfo.status = "restricted";
            context.SaveChanges();
        }

        public int totalServiceCharge()
        {
            int total=0;
            string s;
            var column = context.servicecharges.Where(x => x.amount.Length > 0);
            foreach(var item in column)
            {
                total += Int32.Parse(item.amount);
            }
            return total;
        }

        public void updateAdminInfo(string[] adminInfo)
        {
            string email = adminInfo[0];
            var userinfo = context.userinfoes.First(x=>x.id==1);
            var user = context.users.Where(x=>x.usermail==email).First();
            
            userinfo.firstname = adminInfo[1];
            userinfo.lastname = adminInfo[2];
            userinfo.address = adminInfo[3];
            userinfo.phoneno = adminInfo[4];
            userinfo.status = "permitted";
            if (adminInfo.Length == 6)
            {
                userinfo.password = adminInfo[5];
                user.password = adminInfo[5];
            }
            else
            {
               // userinfo.password = adminInfo[4];

            }

            context.SaveChanges();

            
        }

        public void updateCustSalary(string email, string salary)
        {
            var custcareSalary = context.customercaresalaries.Where(x => x.custcaremail == email).First();
            custcareSalary.previoussalary = custcareSalary.currentsalary;
            custcareSalary.currentsalary = salary;
            context.SaveChanges();
        }

        public int userTypeCount(string type)
        {
            int count = context.users.Where(x=>x.usertype==type).Count();
            return count;
        }


    }
}