using AutoMapper;
using BestCarzOfficialComplaints.Model;
using BestCarzOfficialComplaints.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestCarzOfficialComplaints.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class UsersController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        private readonly IMapper _mapper;
        public UsersController( IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            baseUrl = _configuration.GetValue<string>("BaseUrl:root");
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));
            var dblist = dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("users").AsQueryable();
            //return  await _crudservice.GetAll("Users");
            return dblist;
        }
        [HttpGet]

        public async Task<Users> GetUserById(string id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));
            var dblist = dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("users").AsQueryable().Where(x => x._id == id).FirstOrDefault();
            //return  await _crudservice.GetAll("Users");
            return dblist;
        }
        [HttpPost]
        public async Task<ReturnedUsersDto> CreateUser(CreateUserDto model)
        {
            Users mappeduser = _mapper.Map<Users>(model);
            mappeduser.active = true;
            mappeduser.lastlogin = DateTime.Now;
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));

            dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("users").InsertOne(mappeduser);
            return _mapper.Map<ReturnedUsersDto>(dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("users").AsQueryable().Where(x => x.Username == model.Username).FirstOrDefault());
        }
        [HttpPut]

        public JsonResult EditUser(Users model)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));
            var filter = Builders<Users>.Filter.Eq("_id", model._id);
            //  var update = Builders<Users>.Update.Set("FavouriteBrands", model.FavouriteBrands);
            var updatefullname = Builders<Users>.Update.Set("FullName", model.FullName);
            // dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("users").(filter, update);
            dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("users").UpdateOne(filter, updatefullname);

            return new JsonResult("updated successfully");
        }
        //[HttpDelete("{id}")]
        //[Authorize(Policy = "User")]
        //public async Task<SuccessDTO> Delete(string id)
        //{
        //    MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));
        //    var filter = Builders<Users>.Filter.Eq("_id", id);
        //    dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("users").DeleteOne(filter);

        //    return new SuccessDTO() { Id = 0, SuccessMessage = "Deleted Successfully" };
        //}
        [HttpPost]
        public async Task<ReturnedUsersDto> Login(LoginDto User)
        {
            // TODO: Authenticate Admin with Database
            // If not authenticate return 401 Unauthorized
            // Else continue with below flow
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));
            var dblist = dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("users").AsQueryable().Where(x => x.Username == User.Username && x.password == User.Password).FirstOrDefault();
           if(dblist != null) {
                return _mapper.Map<ReturnedUsersDto>(dblist);
            }
            return null;
        }

    }
}
