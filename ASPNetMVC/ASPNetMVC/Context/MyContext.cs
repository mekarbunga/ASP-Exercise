using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Context
{
    public class MyContext : DbContext
    {
        public MyContext():base("ASPNetMVC")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Account> Accounts { get; set; } 
    }
}