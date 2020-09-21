using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelia.Repository.Login;

namespace travelia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ILoginRepository loginRepo = new LoginRepository();
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
          

            if (collection["remember"] == null)
            {
                HttpCookie ac = Request.Cookies["remember"];
                ac.Value = "true"; 
                Response.Cookies.Add(ac);
                //Response.Cookies["emailcookie"].Expires = DateTime.Now.AddMinutes(-1);
                //Response.Cookies["passwordcookie"].Expires = DateTime.Now.AddMinutes(-1);
                //Response.Cookies["remember"].Expires = DateTime.Now.AddMinutes(-1);

            }
            else
            {
                //Response.Cookies["emailcookie"].Value = Request["email"].ToString();
                //Response.Cookies["passwordcookie"].Value = Request["password"].ToString();
                //Response.Cookies["remember"].Value = "checked";
                //Response.Cookies["emailcookie"].Expires = DateTime.Now.AddMinutes(5);
                //Response.Cookies["passwordcookie"].Expires = DateTime.Now.AddMinutes(5);
                //Response.Cookies["remember"].Expires = DateTime.Now.AddMinutes(5);
                //System.Diagnostics.Debug.WriteLine(Response.Cookies["remember"].Value);

            }
            /////cookies check
            //if (Request["remember"] == null)
            //{
            //    if (Response.Cookies["emailcookie"] != null || Response.Cookies["passwordcookie"] != null)
            //    {
                   
            //        Response.Cookies["remember"].Expires = DateTime.Now.AddMinutes(-1);

            //    }

            //}
            //else
            //{
            //    Response.Cookies["emailcookie"].Value = Request["email"].ToString();
            //    Response.Cookies["passwordcookie"].Value = Request["password"].ToString();
            //    Response.Cookies["remember"].Value = "true";
            //    Response.Cookies["emailcookie"].Expires = DateTime.Now.AddMinutes(5);
            //    Response.Cookies["passwordcookie"].Expires = DateTime.Now.AddMinutes(5);
            //    Response.Cookies["remember"].Expires = DateTime.Now.AddMinutes(5);

            //}

            ////////////

            int login = loginRepo.loginCheck(Request["email"].ToString(),Request["password"].ToString());
            if (login > 0)
            {
                string[] type = loginRepo.userType(Request["email"].ToString());
                Session["loginEmail"] = type[0];
                Session["loginType"] = type[1];
                Session["loginid"] = login;
               
                
                if (type[1] == "admin")
                {
                    return RedirectToAction("Index","Admin");
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

                return RedirectToAction("Index","Travelia");
            }
        }







    }
}