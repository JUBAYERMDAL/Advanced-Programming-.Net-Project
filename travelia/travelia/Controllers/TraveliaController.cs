using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelia.Repository.Travelia;

namespace travelia.Controllers
{
    public class TraveliaController : Controller
    {
        ITraveliaRepository trRepo = new TraveliaRepository();
        // GET: Travelia
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
            ///////////////////
            if (Session["successful"] == null)
            {
                Session["successful"] = "false";
            }
            else
            {
                if (Session["successful"].ToString() == "true")
                {
                    Response.Write("<script>alert('SUCCESSFUL !!');</script>");
                    Session["successful"] = "false";
                }
            }
            //  System.Diagnostics.Debug.WriteLine(Response.Cookies["remember"].ToString());
            if (Request.Cookies["remember"] == null)
            {
                Response.Cookies["remember"].Value = "";
                Response.Cookies["remember"].Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies["emailcookie"].Value = "";
                Response.Cookies["passwordcookie"].Value = "";
                Response.Cookies["emailcookie"].Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies["passwordcookie"].Expires = DateTime.Now.AddMinutes(5);
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {

            if (collection["submit"] =="submit")
            {
                if (collection["remember"] == null)
                {
                    Response.Cookies["remember"].Value = "";
                    Response.Cookies["remember"].Expires = DateTime.Now.AddMinutes(5);
                    Response.Cookies["emailcookie"].Value = "";
                    Response.Cookies["passwordcookie"].Value = "";
                    Response.Cookies["emailcookie"].Expires = DateTime.Now.AddMinutes(5);
                    Response.Cookies["passwordcookie"].Expires = DateTime.Now.AddMinutes(5);

                    int login = trRepo.loginCheck(Request["email"].ToString(), Request["password"].ToString());
                    if (login > 0)
                    {
                        string[] type = trRepo.userType(Request["email"].ToString());
                        Session["loginEmail"] = type[0];
                        Session["loginType"] = type[1];
                        Session["loginid"] = login;


                        if (type[1] == "admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (type[1] == "Traveller")
                        {
                            Session["loginid"] = login;
                            return RedirectToAction("Index", "Traveller");
                        }
                        else if (type[1] == "Hotel Emp")
                        {

                            return RedirectToAction("Index", "Hotel");
                        }
                        else if (type[1] == "Travel guider")
                        {
                            return RedirectToAction("Index", "Guider");
                        }
                        else
                        {
                            //customercare
                            return RedirectToAction("Index", "Admin");
                        }
                    }
                    else
                    {

                        return RedirectToAction("Index", "Travelia");
                    }
                }
                else
                {
                    Response.Cookies["emailcookie"].Value = Request["email"].ToString();
                    Response.Cookies["passwordcookie"].Value = Request["password"].ToString();
                    Response.Cookies["remember"].Value = "checked";
                    Response.Cookies["emailcookie"].Expires = DateTime.Now.AddMinutes(5);
                    Response.Cookies["passwordcookie"].Expires = DateTime.Now.AddMinutes(5);
                    Response.Cookies["remember"].Expires = DateTime.Now.AddMinutes(5);
                    int login = trRepo.loginCheck(Request["email"].ToString(), Request["password"].ToString());
                    if (login > 0)
                    {
                        string[] type = trRepo.userType(Request["email"].ToString());
                        Session["loginEmail"] = type[0];
                        Session["loginType"] = type[1];
                        Session["loginid"] = login;


                        if (type[1] == "admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (type[1] == "Traveller")
                        {
                            Session["loginid"] = login;
                            return RedirectToAction("Index", "Traveller");
                        }
                        else if (type[1] == "Hotel Emp")
                        {

                            return RedirectToAction("Index", "Hotel");
                        }
                        else if (type[1] == "Travel guider")
                        {
                            return RedirectToAction("Index", "Guider");
                        }
                        else
                        {
                            //customercare
                            return RedirectToAction("Index", "Admin");
                        }
                    }
                    else
                    {

                        return RedirectToAction("Index", "Travelia");
                    }
                }
            }
            else
            {
                ////registration
            
            string firstname = collection["firstname"].ToString();
            string lastname = collection["lastname"].ToString();
            string address = collection["address"].ToString();
            string phoneno = collection["phoneno"].ToString();
            string email = collection["email"].ToString();
            string usertype = collection["usertype"].ToString();
            string password = collection["password"].ToString();
            string confirmPassword = collection["password_confirmation"].ToString();
            //string[] values=new string[6];


            if (firstname.Length < 2 || lastname.Length < 2 || address.Length < 2 || phoneno.Length < 3 || password.Length < 6)
            {
                Session["invalidField"] = "true";

                return RedirectToAction("Index");
            }
            else
            {
                //  System.Diagnostics.Debug.WriteLine("in collec1");
                
                    //  System.Diagnostics.Debug.WriteLine("in collec");
                    if (collection["password"].ToString() != collection["password_confirmation"].ToString())
                    {
                        Session["invalidField"] = "true";

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //if they are equal
                        
                        if (password.Length < 6 || !password.Any(char.IsDigit) || !password.Any(char.IsLetter))
                        {
                            //if password doesnt contain any digit or min 6 length or doesnt contain any letter
                            Session["invalidField"] = "true";

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            //values[0] = firstname;
                            //values[1] = lastname;
                            //values[2] = address;
                            //values[3] = phoneno;
                            //values[4] = password;
                            //values[5] = email;

                            trRepo.createNewUser(new string[] { email, firstname, lastname, address, phoneno, password,usertype });
                        Session["successful"] = "true";
                        return RedirectToAction("Index");
                        }
                    }
                    }
            
            }
            return View();
        }





        
    }
}