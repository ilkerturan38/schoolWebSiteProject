using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Episode
    {
        [Key]
        public int episodeID { get; set; }
        public string episodeName { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }

        // Bir Bölümde,Birden Fazla Öğrenci Olabilir.
        public IEnumerable<Student> students { get; set; } 
    }
}
