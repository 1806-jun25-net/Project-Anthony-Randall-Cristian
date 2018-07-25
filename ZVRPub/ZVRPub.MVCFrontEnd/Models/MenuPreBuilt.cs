using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class MenuPreBuilt
    {

        public int Id { get; set; }

        [Required]
        public string NameOfMenu { get; set; }


    }
}
