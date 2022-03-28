using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestCarzOfficialComplaints.Model.Dto
{
    public class SuccessDTO
    {
        public int Id { get; set; }
        public string SuccessMessage { get; set; }
    }
    public class DropDownDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    };
    public class ReturnLoginDto
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
    };
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string password { get; set; }
        public string? FullName { get; set; }
        
      
    }
    public class ReturnedUsersDto
    {
        public string? _id { get; set; }
        public string Username { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Ismechanic { get; set; }
        public string[] Carspeciality { get; set; }
        public bool Issparepartdealer { get; set; }
        public string[] Spareparts { get; set; }
        public string MechanicCategory { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ImageUrl { get; set; }
    }
}
