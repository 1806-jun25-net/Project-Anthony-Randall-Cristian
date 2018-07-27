using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class LogOn
    {

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }



    }
}
