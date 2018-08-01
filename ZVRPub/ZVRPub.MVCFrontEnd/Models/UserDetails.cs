using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.MVCFrontEnd.Models
{
    public class UserDetails
    {

        [JsonProperty("user")]
        public List<User> userInfo { get; set; }
        public int count { get; set; }
    }
}
