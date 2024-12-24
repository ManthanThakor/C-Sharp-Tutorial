using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;
using System.Web.UI.WebControls;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace CRUDDemo.Models
{
    public class CrudContext : DbContext
    {

        public CrudContext() : base("CrudContextDemo")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
