using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Teacher
    {
        [Key]
        public int teacherID { get; set; }
        public string nameSurname { get; set; }
        public string identity { get; set; }
        public int age { get; set; }
        public DateTime birthday { get; set; }
        public string gender { get; set; }
        public string phoneNumber { get; set; }
        public string imageURL { get; set; }

        // Bir Öğretmenin,Birden Fazla Öğrencisi Olabilir.
        public IEnumerable<Student> studentID { get; set; }

        // Bir Öğretmenin Girdiği,Birden Fazla Ders Olabilir.
        public IEnumerable<Lesson> lessons { get; set; }


        // Bir Öğretmenin Girdiği, Birden Fazla Not Olabilir.
        public IEnumerable<Notes> notes { get; set; }

        public int studentCounts { get; set; }
        public int lessonCounts { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string authority { get; set; }
        public bool status { get; set; }
    }
}
