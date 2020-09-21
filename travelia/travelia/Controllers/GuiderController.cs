using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelia.Repository.guider;

namespace travelia.Controllers
{
    public class GuiderController : Controller
    {
        IGuiderRepository guiRepo = new GuiderRepository();
        // GET: Guider
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
        public ActionResult guiderProfile()
        {
            if (Session["invalidField"].ToString() == "true")
            {
                Response.Write("<script>alert('invalid input !!');</script>");
                Session["invalidField"] = "false";
            }
            return View(guiRepo.Get(Int32.Parse(Session["loginid"].ToString())));
        }

        [HttpPost]
        public ActionResult guiderProfile(FormCollection collection)
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

                return RedirectToAction("guiderProfile");
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

                        return RedirectToAction("guiderProfile");
                    }
                    else
                    {
                        //if they are equal
                        string password = collection["password"].ToString();
                        if (password.Length < 6 || !password.Any(char.IsDigit) || !password.Any(char.IsLetter))
                        {
                            //if password doesnt contain any digit or min 6 length or doesnt contain any letter
                            Session["invalidField"] = "true";

                            return RedirectToAction("guiderProfile");
                        }
                        else
                        {
                            //values[0] = firstname;
                            //values[1] = lastname;
                            //values[2] = address;
                            //values[3] = phoneno;
                            //values[4] = password;
                            //values[5] = email;

                            guiRepo.updateGuiderInfo(new string[] { email, firstname, lastname, address, phoneno, password });
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
                    guiRepo.updateGuiderInfo(new string[] { email, firstname, lastname, address, phoneno });
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult guiderMyPlaces()
        {
            return View(guiRepo.getTravelPlace(Session["loginEmail"].ToString()));
        }
        [HttpPost]
        public ActionResult guiderMyPlaces(FormCollection collection)
        {
            string s = collection["submit"];
            if(collection["submit"]=="delete this")
            {
                string image = guiRepo.deleteTravelPlace(collection["travelid"]);
                string imagePath = Request.MapPath("~/Assets/images/travelplace/" + image + ".jpg");
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                guiRepo.deleteMyTravelPlace(collection["travelid"]);
                return RedirectToAction("guiderMyPlaces");
            }
            else
            {
                string id = collection["travelid"];

                return RedirectToAction("guiderUpdatePlace", new  { travelid=id });
            }
        }

        [HttpGet]
        public ActionResult guiderUpdatePlace(string travelid)
        {
            return View(guiRepo.getTravelPlacebyId(travelid));
        }
        [HttpPost]
        public ActionResult guiderUpdatePlace(FormCollection collection, HttpPostedFileBase file)
        {
            string[] info = { collection["placeid"],collection["travelplace"],collection["division"], collection["location"],collection["description"] };
            foreach(var item in info)
            {
                if(item=="" || item == null)
                {
                    Session["invalidField"] = "true";
                    return RedirectToAction("Index");
                }
            }
            if (file == null)
            {
                guiRepo.updateTravelPlace(info);
                return RedirectToAction("guiderMyPlaces");
            }
            else
            {
                string image = guiRepo.deleteTravelPlace(info[0]);
                string imagePath = Request.MapPath("~/Assets/images/travelplace/"+image+".jpg");
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                guiRepo.updateTravelPlace(info);
                guiRepo.updatePicture(info,file);
                return RedirectToAction("guiderMyPlaces");
            }
        }

        [HttpGet]
        public ActionResult guiderAddPlace()
        {
            return View();
        }
        [HttpPost]
        public ActionResult guiderAddPlace(FormCollection collection, HttpPostedFileBase file)
        {
            string[] info = { collection["travelplace"],collection["division"], collection["location"], collection["description"],Session["loginEmail"].ToString() };
            foreach(var item in info)
            {
                if(item=="" || item == null || file==null)
                {
                    Session["invalidField"] = "true";
                    return RedirectToAction("Index");
                }
            }
            guiRepo.insertTravelPlace(info,file);
            return RedirectToAction("guiderMyPlaces");
        }

        [HttpGet]
        public ActionResult guiderDestinations(string division)
        {
            return View(guiRepo.getTravelPlaceByDivision(division));
        }












    }
}