using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace team7WebApp.Models
{
    public class Team7DbContext :DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Request> Request { get; set; }
    }
}