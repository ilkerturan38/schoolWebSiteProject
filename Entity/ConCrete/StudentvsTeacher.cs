using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class StudentvsTeacher // Bu tabloda yapılan işlem Çoktan-Çoğa İlişkidir. N-N
    {
        [Key]
        public int ID { get; set; }

        // 1-1 İlişki Öğrenci Tablosundaki ogrenciID
        public int studentID { get; set; }
        public virtual Student Student { get; set; }

        // 1-1 İlişki Öğretmen Tablosundaki ogretmenID
        public int teacherID { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
