using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoard.Models
{
    public class UserModel
    {
        //   userTB

            public int ID { set; get; }

            [Display(Name = "Matric Number")]
            public string zmatricNumber { set; get; }

            [Display(Name = "Password")]
            public string zpassword { set; get; }

            [Display(Name = "Firstname")]
            public string zfirstname { set; get; }

            [Display(Name = "Lastname")]
            public string zlastname { set; get; }

            [Display(Name = "Department")]
            public string zdepartment { set; get; }

            [Display(Name = "Class")]
            public string zclass { set; get; }

            [Display(Name = "Sex")]
            public string zsex { set; get; }

       

    }
}