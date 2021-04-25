using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoticeBoard.Models
{
    public class NoticeModel
    {

        
            // NoticeboardDb  newsTb
            public int ID { set; get; }

            [Display(Name = "TITLE")]
            public string Title_ns { set; get; }

            [Display(Name = "MESSAGE")]
            public string Message_ns { set; get; }

            [Display(Name = "DATE")]
            public DateTime Date_ns { set; get; }
        }

    }