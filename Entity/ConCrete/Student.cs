using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Student
    {
        [Key]
        public int studentID { get; set; }
        public string nameSurname { get; set; }
        public string identity { get; set; }
        public int age { get; set; }
        public DateTime birthday { get; set; }
        public string gender { get; set; }
        public string phoneNumber { get; set; }
        public string imageURL { get; set; }


        // Bir Öğrencinin,Birden Fazla Öğretmeni Olabilir.
        public IEnumerable<Teacher> teacherID { get; set; }

        // Bir Öğrencinin,Birden Fazla Dersi Olabilir.
        public IEnumerable<Lesson> lessonID { get; set; }

        // Bir Öğrencinin,Okuduğu Sadece Tek Bir Bölüm Olabilir.
        public int episodeID { get; set; }
        public virtual Episode Episode { get; set; }

        // Bir Öğrencinin,Birden Fazla Notu Olabilir.
        public IEnumerable<Notes> notes { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string authority { get; set; }
        public bool status { get; set; }
    }
}
