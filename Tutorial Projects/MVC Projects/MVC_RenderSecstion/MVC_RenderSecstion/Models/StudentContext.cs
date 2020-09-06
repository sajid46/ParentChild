using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVC_RenderSecstion.Models;
using MVC_RenderSecstion.Controllers;


namespace MVC_RenderSecstion.Models
{
    public class StudentContext: DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<StudentContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }

    
}