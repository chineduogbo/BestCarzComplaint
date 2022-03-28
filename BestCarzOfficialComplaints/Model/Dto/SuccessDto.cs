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
}
