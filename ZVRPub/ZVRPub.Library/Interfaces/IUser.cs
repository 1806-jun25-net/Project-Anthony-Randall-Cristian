using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Interfaces
{
    interface IUser
    {
         int UserId { get; set; }
         string Username { get; set; }
         string FirstName { get; set; }
         string LastName { get; set; }
         DateTime DateOfBirth { get; set; }
         string UserAddress { get; set; }
         string PhoneNumber { get; set; }
         string Email { get; set; }
         string UserPic { get; set; }
         
    }
}
