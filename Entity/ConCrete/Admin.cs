using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Admin
    {
        [Key]
        public int adminID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string imageURL { get; set; }
        public string authority { get; set; }
    }
}
