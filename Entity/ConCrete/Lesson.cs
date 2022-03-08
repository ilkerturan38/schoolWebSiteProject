using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Lesson
    {
        [Key]
        public int lessonID { get; set; }
        public string lessonName { get; set; }

        // Bir Dersin,Yalnızca Bir Öğretmeni Olabilir.
        public int? teacherID { get; set; }
        public virtual Teacher teacher { get; set; }

        // Bir Dersin Yalnızca Bir Öğrencisi Olabilir.
        public int? StudentID { get; set; }
        public virtual Student student { get; set; }


        // Bir Derse ait,Birden Fazla Not Olabilir.
        public ICollection<Notes> notes { get; set; }

    }
}
