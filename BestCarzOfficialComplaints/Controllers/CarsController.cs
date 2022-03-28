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
    public class CarsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        private readonly IMapper _mapper;
        public CarsController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            baseUrl = _configuration.GetValue<string>("BaseUrl:root");
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<IEnumerable<CarsDto>> GetAllCars(string UserId)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));
            var dblist = dbClient.GetDatabase("BestCarzLog").GetCollection<Cars>("cars").AsQueryable().Where(x=>x.Userid == UserId).ToList();
            //return  await _crudservice.GetAll("Users");
            return _mapper.Map<IEnumerable<CarsDto>>(dblist);
        }
    

      
        [HttpPost]
        public async Task<IEnumerable<CarsDto>> CreateCar(CreateCarsDto model)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));

            dbClient.GetDatabase("BestCarzLog").GetCollection<Cars>("cars").InsertOne(_mapper.Map<Cars>(model));

            var dblist = dbClient.GetDatabase("BestCarzLog").GetCollection<Cars>("cars").AsQueryable().Where(x => x.Userid == model.Userid).ToList();
            //return  await _crudservice.GetAll("Users");
            return _mapper.Map<IEnumerable<CarsDto>>(dblist);
        }
        //[HttpPut]

        //public JsonResult EditUser(Users model)
        //{
        //    MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));
        //    var filter = Builders<Users>.Filter.Eq("_id", model._id);
        //    var update = Builders<Users>.Update.Set("FavouriteBrands", model.FavouriteBrands);
        //    var updatefullname = Builders<Users>.Update.Set("FullName", model.FullName);
        //    dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("cars").UpdateOne(filter, update);
        //    dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("cars").UpdateOne(filter, updatefullname);

        //    return new JsonResult("updated successfully");
        //}
        [HttpDelete("{id}")]
        public async Task<SuccessDTO> Delete(string id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("orderxconnection"));
            var filter = Builders<Users>.Filter.Eq("_id", id);
            dbClient.GetDatabase("BestCarzLog").GetCollection<Users>("cars").DeleteOne(filter);

            return new SuccessDTO() { Id = 0, SuccessMessage = "Deleted Successfully" };
        }

    }
}
