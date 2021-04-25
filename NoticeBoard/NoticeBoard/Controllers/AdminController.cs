using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoticeBoard.Models;
using NoticeBoard.Context;

namespace NoticeBoard.Controllers
{
    public class AdminController : Controller
    {


        public ActionResult Create()
        {
            if (Session["matric"] != null && Session["pass"] != null)
            {
                return View();
            }
            return RedirectToAction("index", "Admin");
        }

        [HttpPost]
        public ActionResult Create(NoticeModel notice)
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {
                NoticeContext ncc = new NoticeContext();

                notice.Date_ns = DateTime.Today;
                ncc.AddNotice(notice);

                return RedirectToAction("Allnotice");
            }
            return RedirectToAction("index", "Admin");

        }

        // DELETEList

        [ActionName("DELETEList")]
        public ActionResult Deletel()
        {


            if (Session["matric"] != null && Session["pass"] != null)
            {
                NoticeContext ntc = new NoticeContext();
                List<NoticeModel> nm = ntc.allNotice.ToList();

                return View(nm);
            }
            return RedirectToAction("index", "Admin");




        }

        public ActionResult Details(int id)
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {


                NoticeContext ncc = new NoticeContext();
                NoticeModel b = ncc.allNotice.Single(n => n.ID == id);
                return View(b);
            }
            return RedirectToAction("index", "Admin");

        }


        [ActionName("Noticlist")]
        public ActionResult Noticlist()
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {

                NoticeContext ntc = new NoticeContext();
                List<NoticeModel> nm = ntc.allNotice.ToList();

                return View(nm);
            }
            return RedirectToAction("index", "Admin");

        }


        [ActionName("EditList")]
        public ActionResult editLIST()
        {

            if (Session["matric"] != null && Session["pass"] != null)
            {

                NoticeContext ntc = new NoticeContext();
                List<NoticeModel> nm = ntc.allNotice.ToList();

                return View(nm);
            }
            return RedirectToAction("index", "Admin");
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult editPost(NoticeModel idEdit)
        {
            if (Session["matric"] != null && Session["pass"] != null)
            {

                NoticeContext bcv = new NoticeContext();

                if (ModelState.IsValid)
                {
                    bcv.EditNotice(idEdit);
                    return RedirectToAction("EditList");

                }

                NoticeModel nt = bcv.allNotice.Single(s => s.ID == idEdit.ID);
                return View(nt);
            }
            return RedirectToAction("index", "Admin");


        }


        [HttpGet]
        [ActionName("Edit")]
        public ActionResult editgET(int id)
        {
            if (Session["matric"] != null && Session["pass"] != null)
            {

                NoticeContext bcv = new NoticeContext();
                NoticeModel nt = bcv.allNotice.Single(s => s.ID == id);

                return View(nt);
            }
            return RedirectToAction("index", "Admin");




        }


        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {


            if (Session["matric"] != null && Session["pass"] != null)
            {
                NoticeContext bcn = new NoticeContext();
                NoticeModel bk = bcn.allNotice.Single(s => s.ID == id);

                return View(bk);

            }
            return RedirectToAction("index", "Admin");



        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteGet(NoticeModel buk)
        {


            if (Session["matric"] != null && Session["pass"] != null)
            {
                NoticeContext bcn = new NoticeContext();
                bcn.Delete_Notice(buk);
                return RedirectToAction("DELETEList");

            }
            return RedirectToAction("index", "Admin");




        }


        public ActionResult LogOut()
        {

            Session.Abandon();
            return RedirectToAction("index", "Admin");
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string password, string matricNumber)
        {
            if (ModelState.IsValid)
            {
                UserContext uc = new UserContext();
                int zcount = uc.allUser.Where(u => u.zpassword == password && u.zmatricNumber == matricNumber).Count();

                if (zcount > 0)
                {
                    UserModel usm = uc.allUser.Where(u => u.zpassword == password && u.zmatricNumber.ToUpper() == matricNumber.ToUpper()).Single();

                    Session["matric"] = usm.zmatricNumber;
                    Session["pass"] = usm.zpassword;
                    Session["UID"] = usm.ID;
                    Session["nam"] = usm.zfirstname + " " + usm.zlastname;

                    return RedirectToAction("Allnotice", "Admin");
                }
            }
            if (password == "" || matricNumber == "")
            {
                if (matricNumber == null || matricNumber == "")
                {
                    ViewBag.matri = "require matricNumber";
                }
                if (password == null || password == "")
                {
                    ViewBag.passer = "require password";
                }
            }

            else
            {
                ViewBag.loginerror = "WRONG LOGIN";
            }
            return View();

        }


        public ActionResult Allnotice()
        {


            if (Session["matric"] != null && Session["pass"] != null)
            {


                NoticeContext ntc = new NoticeContext();

                return View(ntc.allNotice.ToList());

            }
            return RedirectToAction("index", "Admin");
        }

    }
}