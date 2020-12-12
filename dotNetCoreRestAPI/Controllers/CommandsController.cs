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
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var command = _db.GetCommandById(id);
            if (command == null) return NotFound();
            return Ok(_mapper.Map<CommandReadDTO>(command));
        }

        //responds to post requests with uri: api/commands
        //returns the created object
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO cmdCreateDTO)
        {
            if (cmdCreateDTO == null) throw new ArgumentNullException(nameof(cmdCreateDTO));
            var command = _mapper.Map<Commands>(cmdCreateDTO);
            _db.CreateCommand(command);
            _db.SaveChanges();
            var commandReadDTO = _mapper.Map<CommandReadDTO>(command);
            //return Ok(_mapper.Map<CommandReadDTO>(command));
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO);
        }

        //responds to the put requests with uri: api/commands/id
        //this is inefficient; client must provide the whole object to perform update- prone to error
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO cmdUpdateDTO)
        {
            var commandToUpdate = _db.GetCommandById(id);
            if (commandToUpdate == null) return NotFound();

            //takes care of updating- hence empty interface implementation
            _mapper.Map(cmdUpdateDTO, commandToUpdate);

            //just in case later in future you need more specific update implementation
            _db.UpdateCommand(commandToUpdate);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
