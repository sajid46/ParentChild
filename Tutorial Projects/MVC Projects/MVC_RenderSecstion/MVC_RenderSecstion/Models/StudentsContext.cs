using MVC_RenderSecstion.Controllers;
using System.Data.Entity;

namespace MVC_RenderSecstion.Models
{
    public class StudentsContext: DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<StudentsContext>(null);
            base.OnModelCreating(modelBuilder);
        }

    }
}