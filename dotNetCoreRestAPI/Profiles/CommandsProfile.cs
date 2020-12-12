using AutoMapper;
using dotNetCoreRestAPI.DTOs;
using dotNetCoreRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //for read- convert domain model to dto
            CreateMap<Commands, CommandReadDTO>();

            //for create- convert dto to domain model
            CreateMap<CommandCreateDTO, Commands>();
        }
    }
}
