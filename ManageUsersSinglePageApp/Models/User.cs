using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageUsersCoreApp.Models
{
    public class User
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string Name { get; set; }

        //public int Age { get; set; }

        //[MaxLength(50)]
        //public string Address { get; set; }

        
        public string Name { get; set; }

        public int? Age { get; set; }

        
        public string Address { get; set; }
    }
}