using AutoMapper;
using BestCarzOfficialComplaints.Model;
using BestCarzOfficialComplaints.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestCarzOfficialComplaints.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, Users>();
            CreateMap<Users, ReturnedUsersDto>();
        }
    }
   }
