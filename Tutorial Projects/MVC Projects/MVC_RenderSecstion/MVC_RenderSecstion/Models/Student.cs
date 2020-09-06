using System.ComponentModel.DataAnnotations;

namespace MVC_RenderSecstion.Controllers
{
    public class Student
    {
        [Key]
        public int StudentID { get; set;}
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentAddress { get; set; }

    }
}