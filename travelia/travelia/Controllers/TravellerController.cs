using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelia.Repository.Traveller;

namespace travelia.Controllers
{
    public class TravellerController : Controller
    {
        // GET: Traveller
        ITravellerRepository trRepo = new TravellerRepository();
        public ActionResult Index()
        {
            if (Session["invalidField"] == null)
            {
            Session["invalidField"] = "false";

            }
            else
            {
                if (Session["invalidField"].ToString() == "true")
                {
                    Response.Write("<script>alert('invalid input !!');</script>");
                    Session["invalidField"] = "false";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult travellerProfile()
        {
            if (Session["invalidField"].ToString() == "true")
            {
                Response.Write("<script>alert('invalid input !!');</script>");
                Session["invalidField"] = "false";
            }
            int id = Int16.Parse(Session["loginid"].ToString());//session saved as loginid
            return View(trRepo.Get(id));
        }
        [HttpPost]
        public ActionResult travellerProfile(FormCollection collection)
        {
            if(collection["submit"]== "Delete")
            {
                trRepo.deleteTravellerAccount(Session["loginid"].ToString());
                return RedirectToAction("Index","logout");
            }
            string firstname = collection["firstname"].ToString();
            string lastname = collection["lastname"].ToString();
            string address = collection["address"].ToString();
            string phoneno = collection["phoneno"].ToString();
            string email = collection["email"].ToString();
            //string[] values=new string[6];


            if (firstname.Length < 2 || lastname.Length < 2 || address.Length < 2 || phoneno.Length < 3)
            {
                Session["invalidField"] = "true";

                return RedirectToAction("travellerProfile");
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

                        return RedirectToAction("travellerProfile");
                    }
                    else
                    {
                        //if they are equal
                        string password = collection["password"].ToString();
                        if (password.Length < 6 || !password.Any(char.IsDigit) || !password.Any(char.IsLetter))
                        {
                            //if password doesnt contain any digit or min 6 length or doesnt contain any letter
                            Session["invalidField"] = "true";

                            return RedirectToAction("travellerProfile");
                        }
                        else
                        {
                            //values[0] = firstname;
                            //values[1] = lastname;
                            //values[2] = address;
                            //values[3] = phoneno;
                            //values[4] = password;
                            //values[5] = email;

                            trRepo.updateTravellerInfo(new string[] { email, firstname, lastname, address, phoneno, password });
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
                    trRepo.updateTravellerInfo(new string[] { email, firstname, lastname, address, phoneno });
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }

        [HttpGet]

        public ActionResult travellerDestination(string destination)
        {
           
            return View(trRepo.getTravelPlace(destination));
        }
        [HttpPost,ActionName("travellerDestination")]

        public ActionResult travellerDestinationPost(string destination)
        {
            string location = Request["location"].ToString();

            return RedirectToAction("searchHotel", new { loc = location });
        }

        [HttpGet]
        public ActionResult searchHotel(string loc)
        {
            return View(trRepo.getHotels(loc));
        }
        [HttpPost]
        public ActionResult searchHotel(FormCollection collection)
        {
            string hotelroom = collection["hotelroom"];
            string hotelempmail = collection["hotelempmail"];
            string hotelname = collection["hotelname"];
            
            return RedirectToAction("travellerBooking", new { hotelroom= hotelroom, hotelempmail= hotelempmail, hotelname = hotelname });
        }

        [HttpGet]
        public ActionResult travellerBooking(string hotelroom,string hotelempmail,string hotelname)
        {
            ViewBag.hotelroom = hotelroom;
            ViewBag.hotelempmail = hotelempmail;
            ViewBag.hotelname = hotelname;
            return View();
        }

        [HttpPost]
        public ActionResult travellerBooking(FormCollection collection)
        {
            DateTime checkin = DateTime.Parse(collection["checkin"]);
            DateTime checkout = DateTime.Parse(collection["checkout"]);
            if (checkin > checkout)
            {
                Session["invalidField"] = "true";
                
                return RedirectToAction("Index");
                
            }
            else
            {
                double days = (checkout - checkin).TotalDays;
                string rent = new string(collection["roomtype"].Where(Char.IsDigit).ToArray());
                int roomrent = Int32.Parse(rent);
                double totalrent = days * roomrent;
                string roomtype = collection["roomtype"];

                string[] bookinginfo = { Session["loginEmail"].ToString(), collection["hotelempmail"], collection["hotelname"], collection["checkin"], collection["checkout"], days.ToString(), roomtype, totalrent.ToString() };
                trRepo.insertBookinginfo(bookinginfo);
                
            }
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult travellerMyBooking()
        {
            return View(trRepo.getMyBooking(Session["loginEmail"].ToString()));
        }

        [HttpPost]
        public ActionResult travellerMyBooking(FormCollection collection)
        {
            if (collection["submit"] == "send")
            {
                string msg = collection["messagebox"];
                string hotelempmail = collection["hotelempmail"];
                string loginmail = Session["loginEmail"].ToString();
                trRepo.messageToHotel(loginmail,hotelempmail,msg);
                return RedirectToAction("travellerMyBooking");
            }
            else
            {
                trRepo.cancelBooking(collection["id"]);
                return RedirectToAction("travellerMyBooking");
            }
        }













        //end
    }
}