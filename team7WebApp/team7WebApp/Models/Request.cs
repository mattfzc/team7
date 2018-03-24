using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace team7WebApp.Models
{
    public class Request
    {
       public int RequestID { get; set; }
       public int InquirerID { get; set; }
       public int DeptID { get; set; }
       public int LiasonID { get; set; }
       [Column(TypeName = "datetime2")]
       public DateTime MeetTime { get; set; }
       public bool HasInquiererAccepted { get; set; }
    }
}