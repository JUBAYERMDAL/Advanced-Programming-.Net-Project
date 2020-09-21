using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using travelia.Repository.Admin;

namespace travelia.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        IAdminRepository adminRepo = new AdminRepository();
        public ActionResult Index()
        {
            //int travellerCount = adminRepo.userTypeCount("Traveller");   
            //int hotelCount = adminRepo.userTypeCount("Hotel Emp");   
            //int guiderCount = adminRepo.userTypeCount("Travel guider");   
            //int careCount = adminRepo.userTypeCount("customercare");

            //int sylhetCount = adminRepo.placeCount("sylhet");
            //int chitCount = adminRepo.placeCount("chittagong");
            //int rajCount = adminRepo.placeCount("rajshahi");
            //int khulnaCount = adminRepo.placeCount("khulna");
            HttpCookie acookie = Request.Cookies["remember"];

            string s = Server.HtmlEncode(acookie.Value);
            Session["invalidField"] = "false";
            ViewBag.travellerCount = adminRepo.userTypeCount("Traveller");   
            ViewBag.hotelCount = adminRepo.userTypeCount("Hotel Emp");   
            ViewBag.guiderCount = adminRepo.userTypeCount("Travel guider");   
            ViewBag.careCount = adminRepo.userTypeCount("customercare");

            ViewBag.sylhetCount = adminRepo.placeCount("sylhet");
            ViewBag.chitCount = adminRepo.placeCount("chittagong");
            ViewBag.rajCount = adminRepo.placeCount("rajshahi");
            ViewBag.khulnaCount = adminRepo.placeCount("khulna");
            
            return View();
        }

        [HttpGet]
        public ActionResult adminProfile()
        {
            if (Session["invalidField"].ToString() == "true")
            {
                Response.Write("<script>alert('invalid input !!');</script>");
                Session["invalidField"] = "false";
            }
            return View(adminRepo.Get(1));
        }
        [HttpPost,ActionName("adminProfile")]
        public ActionResult adminProfilePost(FormCollection collection)
        {
           
            string firstname = collection["firstname"].ToString();
            string lastname = collection["lastname"].ToString();
            string address = collection["address"].ToString();
            string phoneno = collection["phoneno"].ToString();
            string email = collection["email"].ToString();
            //string[] values=new string[6];
            
            
            if(firstname.Length<2 || lastname.Length<2 || address.Length<2 || phoneno.Length < 3)
            {
                Session["invalidField"] = "true";
                
                return RedirectToAction("adminProfile");
            }
            else
            {
              //  System.Diagnostics.Debug.WriteLine("in collec1");
                if (collection["password"].ToString().Length>5)
                {
                  //  System.Diagnostics.Debug.WriteLine("in collec");
                    if (collection["password"].ToString() != collection["password_confirmation"].ToString())
                    {
                        Session["invalidField"] = "true";

                        return RedirectToAction("adminProfile");
                    }
                    else
                    {
                        //if they are equal
                        string password = collection["password"].ToString();
                        if(password.Length<6 || !password.Any(char.IsDigit) || !password.Any(char.IsLetter))
                        {
                            //if password doesnt contain any digit or min 6 length or doesnt contain any letter
                            Session["invalidField"] = "true";

                            return RedirectToAction("adminProfile");
                        }
                        else
                        {
                            //values[0] = firstname;
                            //values[1] = lastname;
                            //values[2] = address;
                            //values[3] = phoneno;
                            //values[4] = password;
                            //values[5] = email;
                            
                            adminRepo.updateAdminInfo(new string[] { email,firstname,lastname,address,phoneno,password });
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    //System.Diagnostics.Debug.WriteLine("in admin");
                    //if password not changed
                    //values[0] = firstname;
                    //values[1] = lastname;
                    //values[2] = address;
                    //values[3] = phoneno;
                    //values[4] = email;
                    adminRepo.updateAdminInfo(new string[] {email, firstname, lastname, address, phoneno });
                    return RedirectToAction("Index");
                }
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult adminTraveller()
        {
            
            return View(adminRepo.getUserInfo("Traveller"));
        }
        [HttpPost]
        public ActionResult adminTraveller(FormCollection collection)
        {
            switch (collection["submit"])
            {
                case "permitted":
                    adminRepo.permittedToRestricted(collection["email"]);
                    break;
                case "restricted":
                    adminRepo.restrictedToPermitted(collection["email"]);
                    break;
                case "delete account":
                    adminRepo.deleteAccount(collection["email"]);
                    break;
            }
            return RedirectToAction("adminTraveller");
        }
        [HttpGet]
        public ActionResult adminTravelGuide()
        {
            
            return View(adminRepo.getUserInfo("Travel guider"));
        }

        [HttpPost]
        public ActionResult adminTravelGuide(FormCollection collection)
        {
            switch (collection["submit"])
            {
                case "permitted":
                    adminRepo.permittedToRestricted(collection["email"]);
                    break;
                case "restricted":
                    adminRepo.restrictedToPermitted(collection["email"]);
                    break;
                case "delete account":
                    adminRepo.deleteAccount(collection["email"]);
                    break;
            }
            return RedirectToAction("adminTravelGuide");

        }

        [HttpGet]
        public ActionResult adminHotelEmp()
        {
            
            return View(adminRepo.getUserInfo("Hotel Emp"));
        }
        [HttpPost]
        public ActionResult adminHotelEmp(FormCollection collection)
        {
            switch (collection["submit"])
            {
                case "permitted":
                    adminRepo.permittedToRestricted(collection["email"]);
                    break;
                case "restricted":
                    adminRepo.restrictedToPermitted(collection["email"]);
                    break;
                case "delete account":
                    adminRepo.deleteAccount(collection["email"]);
                    break;
            }
            return RedirectToAction("adminHotelEmp");

        }

        [HttpGet]
        public ActionResult adminCustCare()
        {
            
            return View(adminRepo.getUserInfo("customercare"));
        }

        [HttpPost]
        public ActionResult adminCustCare(FormCollection collection)
        {
            switch (collection["submit"])
            {
                case "permitted":
                    adminRepo.permittedToRestricted(collection["email"]);
                    break;
                case "restricted":
                    adminRepo.restrictedToPermitted(collection["email"]);
                    break;
                case "delete account":
                    adminRepo.deleteAccount(collection["email"]);
                    break;
            }
            return RedirectToAction("adminCustCare");

        }

        [HttpGet]
        public ActionResult adminHotelinfo()
        {
            return View(adminRepo.getHotelInfo());
        }

        [HttpPost]
        public ActionResult adminHotelinfo(FormCollection collection)
        {
            switch (collection["submit"])
            {
                case "permit":
                    adminRepo.permitHotel(collection["hotelname"]);
                    break;
                case "restrict":
                    adminRepo.restrictHotel(collection["hotelname"]);
                    break;
                case "delete this":
                    adminRepo.deleteHotel(collection["hotelname"]);
                    break;
            }
            return RedirectToAction("adminHotelinfo");
        }

        [HttpGet]
        public ActionResult adminTravelPlace()
        {
            return View(adminRepo.getTravelPlaces());
        }

        [HttpPost]
        public ActionResult adminTravelPlace(FormCollection collection)
        {

            string[] picture=adminRepo.deleteTravelPlace(collection["travelplace"]);
            string picturePath = Request.MapPath("~/Assets/images/travelplace/"+picture[0]+"/"+picture[1]+".jpg");
            System.Diagnostics.Debug.WriteLine(picturePath);
            if (System.IO.File.Exists(picturePath))
            {
                System.IO.File.Delete(picturePath);
            }

            return RedirectToAction("adminTravelPlace");
        }

        [HttpGet]
        public ActionResult adminAddCust()
        {
            if (Session["invalidField"].ToString() == "true")
            {
                Response.Write("<script>alert('invalid input !!');</script>");
                Session["invalidField"] = "false";
            }
            return View();
        }

        [HttpPost]
        public ActionResult adminAddCust(FormCollection collection)
        {
            string firstname = collection["firstname"].ToString();
            string lastname = collection["lastname"].ToString();
            string address = collection["address"].ToString();
            string phoneno = collection["phoneno"].ToString();
            string email = collection["email"].ToString();
            string password = collection["password"].ToString();
            string passwordConfirm = collection["password_confirmation"].ToString();
            //string[] values=new string[6];


            if (firstname.Length < 2 || lastname.Length < 2 || address.Length < 2 || phoneno.Length < 3 || password.Length<6)
            {
                Session["invalidField"] = "true";

                return RedirectToAction("adminAddCust");
            }
            else
            {
                //  System.Diagnostics.Debug.WriteLine("in collec1");
                if (collection["password"].ToString().Length > 5)
                {
                    //  System.Diagnostics.Debug.WriteLine("in collec");
                    if (collection["password"].ToString() != collection["password_confirmation"].ToString())
                    {
                        Session["invalidField"] = "true";

                        return RedirectToAction("adminAddCust");
                    }
                    else
                    {
                        //if they are equal
                        //string password = collection["password"].ToString();
                        if (password.Length < 6 || !password.Any(char.IsDigit) || !password.Any(char.IsLetter))
                        {
                            //if password doesnt contain any digit or min 6 length or doesnt contain any letter
                            Session["invalidField"] = "true";

                            return RedirectToAction("adminAddCust");
                        }
                        else
                        {
                            //values[0] = firstname;
                            //values[1] = lastname;
                            //values[2] = address;
                            //values[3] = phoneno;
                            //values[4] = password;
                            //values[5] = email;

                            //adminRepo.updateAdminInfo(new string[] { email, firstname, lastname, address, phoneno, password });
                            adminRepo.insertCastomerCareAccount(new string[] { firstname,lastname,email,password,"customercare",address,phoneno,"permitted" });
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    //System.Diagnostics.Debug.WriteLine("in admin");
                    //if password not changed
                    //values[0] = firstname;
                    //values[1] = lastname;
                    //values[2] = address;
                    //values[3] = phoneno;
                    //values[4] = email;
                    // adminRepo.updateAdminInfo(new string[] { email, firstname, lastname, address, phoneno });
                    Session["invalidField"] = "true";

                    return RedirectToAction("adminAddCust");
                }
            }

            return View("Index");
            
        }


        [HttpGet]
        public ActionResult adminCustAudit()
        {

            return View(adminRepo.getCustomerCareSalarySheet());
        }
        [HttpPost]
        public ActionResult adminCustAudit(FormCollection collection)
        {
            switch (collection["submit"])
            {
                case "submit":
                    adminRepo.addCustCareSalary(collection["email"],collection["salary"]);
                    return RedirectToAction("adminCustAudit");
                    break;
                case "update":
                    adminRepo.updateCustSalary(collection["email"],collection["newsalary"]);
                    return RedirectToAction("adminCustAudit");
                    break;
                case "delete entry":
                    adminRepo.deleteCustSalaryEntry(collection["email"]);
                    return RedirectToAction("adminCustAudit");
                    break;
                case "salary sheet":
                    Session["custsalaryemail"] = collection["email"];
                    return RedirectToAction("adminCustSalarySheet");
                    break;
            }
            return RedirectToAction("adminCustAudit");
        }

        [HttpGet]
        public ActionResult adminCustSalarySheet()
        {
            return View(adminRepo.custCareSalarySheet(Session["custsalaryemail"].ToString()));
        }
        [HttpPost]
        public ActionResult adminCustSalarySheet(FormCollection collection)
        {
            switch (collection["submit"])
            {
                case "delete entry":
                    adminRepo.deletecustCareSalarySheet(collection["email"], collection["month"]);
                    break;
                case "submit":
                    adminRepo.insertCustCareSalarySheet(collection["email"], collection["month"], collection["amount"]);
                    
                    break;
            }
           // adminRepo.insertCustCareSalarySheet(collection["email"], collection["month"], collection["amount"]);
            return RedirectToAction("adminCustSalarySheet");
        }

        [HttpGet]

        public ActionResult adminServiceCharge()
        {
            ViewBag.totalAmount = adminRepo.totalServiceCharge();
            return View(adminRepo.adminServiceCharge());
        }

        [HttpPost]
        public ActionResult adminServiceCharge(FormCollection collection)
        {
            switch (collection["submit"])
            {
                case "delete entry":
                    adminRepo.deleteServiceCharge(collection["id"]);
                    break;
                case "submit":
                    adminRepo.insertServiceCharge(collection["email"],collection["month"],collection["amount"]);
                    break;
            }
            return RedirectToAction("adminServiceCharge");
        }


















    }
}