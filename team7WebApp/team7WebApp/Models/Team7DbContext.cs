using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace team7WebApp.Models
{
    public class Team7DbContext :DbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<Department> Department { get; set; }
    }
}