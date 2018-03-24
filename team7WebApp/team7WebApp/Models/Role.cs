using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team7WebApp.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; } //eg, Inqiuerer, SME

        /*if Requests true and Assign false, Liazon
          if Requests true and Assign true, Coordinator*/
        public bool CanTakeRequests { get; set; }//if true, role is Liazon
        public bool CanAssign { get; set; }//if true, coordinator
    }
}