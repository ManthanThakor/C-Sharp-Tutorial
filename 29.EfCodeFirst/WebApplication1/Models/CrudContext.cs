using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WebApplication1.Models
{
    public class CrudContext : DbContext
    {

        public CrudContext() : base("CRUDDemoScap")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}