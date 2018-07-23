using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Interfaces
{
    interface IUserLoginInfo
    {
        string UserName{ get; set; }
        string Password { get; set; }
    }
}
