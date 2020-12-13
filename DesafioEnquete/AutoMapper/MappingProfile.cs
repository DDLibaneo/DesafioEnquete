using AutoMapper;
using DesafioEnquete.Dtos;
using DesafioEnquete.Dtos.DtoOut;
using DesafioEnquete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEnquete.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DtoIn to Domain 
            CreateMap<PollDtoIn, Poll>();
            CreateMap<OptionDtoIn, Option>();

            // Domain to DtoOut
            CreateMap<Poll, PollDtoOut>();
            CreateMap<Option, OptionDtoOut>();
        }
    }
}
