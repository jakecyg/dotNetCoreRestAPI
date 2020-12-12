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
        public CommandsProfile() => CreateMap<Commands, CommandReadDTO>();
    }
}
