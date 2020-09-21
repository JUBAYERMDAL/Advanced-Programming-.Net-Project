using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelia.Repository.Hotel;

namespace travelia.Controllers
{
    public class HotelController : Controller
    {
        IHotelRepository hotelRepo = new HotelRepository();
        // GET: Hotel
        [HttpGet]
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
            return View(hotelRepo.gethotel(Session["loginEmail"].ToString()));
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string[] hotelinfo = { collection["hotelname"], collection["totalroom"], collection["singlebed"], collection["doublebed"], collection["suit"]};
            foreach(var item in hotelinfo)
            {
                if (item == "")
                {
                    Session["invalidField"]= "true";
                    return RedirectToAction("Index");
                }
            }
            if (collection["submit"] == "delete")
            {
                string imagePath = hotelRepo.deleteImage(Session["loginEmail"].ToString());
                imagePath = Request.MapPath("~/Assets/images/hotel/" + imagePath + ".jpg");
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                hotelRepo.deleteHotelinfo(Session["loginEmail"].ToString());
                return RedirectToAction("Index");
            }
            else
            {
                hotelRepo.updateHotelinfo(Session["loginEmail"].ToString(),hotelinfo);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult hotelProfile()
        {
            if (Session["invalidField"].ToString() == "true")
            {
                Response.Write("<script>alert('invalid input !!');</script>");
                Session["invalidField"] = "false";
            }
            return View( hotelRepo.Get(Int32.Parse(Session["loginid"].ToString())));
        }
        [HttpPost]
        public ActionResult hotelProfile(FormCollection collection)
        {
            string firstname = collection["firstname"].ToString();
            string lastname = collection["lastname"].ToString();
            string address = collection["address"].ToString();
            string phoneno = collection["phoneno"].ToString();
            string email = collection["email"].ToString();
            //string[] values=new string[6];


            if (firstname.Length < 2 || lastname.Length < 2 || address.Length < 2 || phoneno.Length < 3)
            {
                Session["invalidField"] = "true";

                return RedirectToAction("hotelProfile");
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

                        return RedirectToAction("hotelProfile");
                    }
                    else
                    {
                        //if they are equal
                        string password = collection["password"].ToString();
                        if (password.Length < 6 || !password.Any(char.IsDigit) || !password.Any(char.IsLetter))
                        {
                            //if password doesnt contain any digit or min 6 length or doesnt contain any letter
                            Session["invalidField"] = "true";

                            return RedirectToAction("hotelProfile");
                        }
                        else
                        {
                            //values[0] = firstname;
                            //values[1] = lastname;
                            //values[2] = address;
                            //values[3] = phoneno;
                            //values[4] = password;
                            //values[5] = email;

                            hotelRepo.updateHotelEmpInfo(new string[] { email, firstname, lastname, address, phoneno, password });
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
                    hotelRepo.updateHotelEmpInfo(new string[] { email, firstname, lastname, address, phoneno });
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult hotelAdd()
        {
            return View(hotelRepo.getTravelPlaces());
        }
        [HttpPost]
        public ActionResult hotelAdd(FormCollection collection,HttpPostedFileBase file)
        {

            string imagename = Path.GetFileNameWithoutExtension(file.FileName);
            string email = Session["loginEmail"].ToString();
           
            string[] hotelEmpInfo = { email, collection["hotelname"], collection["division"], collection["location"], collection["totalroom"], collection["singlebed"], collection["doublebed"], collection["suitbed"], collection["description"] ,imagename};
            foreach(var item in hotelEmpInfo)
            {
                if(item==""|| item == null)
                {
                    Session["invalidField"] = "true";
                    return RedirectToAction("Index");
                }
            }
            hotelRepo.insertHotel(hotelEmpInfo,file);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult hotelReq()
        {
            return View(hotelRepo.getBookingInfo(Session["loginEmail"].ToString()));
        }











    }
}