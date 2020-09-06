using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation_LINQ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
             new Student{ ID=1, StudentName="Sajid", Country="Pakistan", Scores= new List<int>{2,10,24,121} },
             new Student{ID=2,  StudentName="Naeem", Country="Pakistan", Scores=new List<int>{23,22,55,23,145}} ,
             new Student{ID=3,  StudentName="Singh", Country="India", Scores=new List<int>{23,22,55,23,145}} ,
             new Student{ID=4,  StudentName="Ravi", Country="India", Scores=new List<int>{23,22,55,23,145}} ,
             new Student{ID=5,  StudentName="James", Country="England", Scores=new List<int>{23,22,55,23,145}} ,
            };

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher{ID=1, TeacherName="Khalid Teacher", Country="Pakistan"},
                new Teacher{ID=2, TeacherName="Asif Teacher", Country="Pakistan"},
                new Teacher{ID=3, TeacherName="Jara Teacher", Country="India"},
                new Teacher{ID=4, TeacherName="Paul Teacher", Country="England"},
                new Teacher{ID=5, TeacherName="Paulo Teacher", Country="Italy"}
            };

            //var results = (from s in students select s).ToList();

            var results = (from s in students where s.Country == "Pakistan" select s.StudentName).Concat
                            (from t in teachers where t.Country == "Pakistan" select t.TeacherName).ToList();
                

            foreach (var item in results)
            {
                Console.WriteLine($"Name: {item}  "   );
            }
            Console.ReadLine();


        }
    }

    internal class Teacher
    {
        public int ID { get; set; }
        public string TeacherName { get; set; }
        public string Country { get; set; }
    }

    internal class Student
    {
        public string StudentName { get; set; }
        public int ID { get; set; }
        public string Country { get; set; }
        public List<int> Scores { get; set; }
    }
}
