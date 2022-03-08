using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Notes
    {
        [Key]
        public int notesID { get; set; }
        public float note1 { get; set; }
        public float note2 { get; set; }
        public float note3 { get; set; }
        public float average { get; set; }
        public bool status { get; set; }


        // Bir Not Yalnızca Bir Öğrenciye ait Olabilir.
        public int studentID { get; set; }
        public virtual Student Student { get; set; }

        // Bir Not Yalnızca Bir Derse ait Olabilir.
        public int lessonID { get; set; }
        public virtual Lesson Lesson { get; set; }

        // Bir Notu Yalnızca,Bir Öğretmen Verebilir.
        public int? teacherID { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
