using AutoMapper;
using dotNetCoreRestAPI.Data;
using dotNetCoreRestAPI.DTOs;
using dotNetCoreRestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.Controllers
{
    //ApiController = provides some out of the box functionalities
    [ApiController]
    //api/commands 
    [Route("api/[controller]")]
    public class CommandsController : Controller
    {
        private readonly ICommandsRepo _db;
        private readonly IMapper _mapper;

        //Inject dependency
        public CommandsController(ICommandsRepo dn, IMapper mapper)
        {
            _db = dn;
            _mapper = mapper;
        }

        //respond to HttpGet requests with uri: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commands = _db.GetAllCommands();
            //return 200 success
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        //respond to get requests with uri: api/commands/id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CommandReadDTO>> GetComandById(int id)
        {
            var command = _db.GetCommandById(id);
            if (command == null) return NotFound();
            return Ok(_mapper.Map<CommandReadDTO>(command));
        }
    }
}
