using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoticeBoard.Models;
using NoticeBoard.Context; 

namespace NoticeBoard.Controllers
{
    public class UserController : Controller
    {



        public ActionResult Detaillist()
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {
                UserContext usc = new UserContext();
                return View(usc.allUser.ToList());

            }
            return RedirectToAction("index", "Admin");

        }

        [ActionName("Details")]
        public ActionResult Details(int id)
        {


            if (Session["matric"] != null && Session["pass"] != null)
            {
                UserContext uc = new UserContext();

                return View(uc.allUser.Where(k => k.ID == id).Single());

            }
            return RedirectToAction("index", "Admin");



        }





        public ActionResult EditList()
        {


            if (Session["matric"] != null && Session["pass"] != null)
            {
                UserContext usc = new UserContext();
                return View(usc.allUser.ToList());

            }
            return RedirectToAction("index", "Admin");

        }

        [HttpPost]
        public ActionResult Edit(UserModel userid)
        {
            if (Session["matric"] != null && Session["pass"] != null)
            {


                UserContext uc = new UserContext();
                uc.Edituser(userid);
                return RedirectToAction("index");

            }
            return RedirectToAction("index", "Admin");

        }

        [ActionName("Edit")]
        public ActionResult Editget(int id)
        {


            if (Session["matric"] != null && Session["pass"] != null)
            {
                UserContext uc = new UserContext();

                return View(uc.allUser.Where(k => k.ID == id).Single());

            }
            return RedirectToAction("index", "Admin");

        }






        public ActionResult DELETEList()
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {

                UserContext usc = new UserContext();
                return View(usc.allUser.ToList());
            }
            return RedirectToAction("index", "Admin");

        }

        [ActionName("Delete")]
        public ActionResult Deleteget(int id)
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {

                UserContext uc = new UserContext();

                return View(uc.allUser.Where(k => k.ID == id).Single());
            }
            return RedirectToAction("index", "Admin");

        }

        [HttpPost]
        public ActionResult Delete(UserModel uid)
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {
                UserContext uc = new UserContext();
                uc.Deleteuser(uid);
                return RedirectToAction("index");

            }
            return RedirectToAction("index", "Admin");


        }





        [HttpPost]
        public ActionResult Create(UserModel useradd)
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {

                UserContext usc = new UserContext();
                usc.AddUser(useradd);
                return RedirectToAction("index");

            }
            return RedirectToAction("index", "Admin");

        }

        public ActionResult Create()
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {

                return View();

            }
            return RedirectToAction("index", "Admin");

        }




        public ActionResult Index()
        {
            if (Session["matric"] != null && Session["pass"] != null)
            {

                UserContext usc = new UserContext();
                return View(usc.allUser.ToList());
            }
            return RedirectToAction("index", "Admin");

        }

    }
}