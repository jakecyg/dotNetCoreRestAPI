using AutoMapper;
using dotNetCoreRestAPI.Data;
using dotNetCoreRestAPI.DTOs;
using dotNetCoreRestAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<ActionResult<IEnumerable<CommandReadDTO>>> GetAllCommands()
        {
            var commands = await _db.GetAllCommandsAsync();
            //return 200 success
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        //respond to get requests with uri: api/commands/id
        [HttpGet("{id}", Name = "GetCommandById")]
        public async Task<ActionResult<CommandReadDTO>> GetCommandById(int id)
        {
            var command = await _db.GetCommandByIdAsync(id);
            if (command == null) return NotFound();
            return Ok(_mapper.Map<CommandReadDTO>(command));
        }

        //responds to post requests with uri: api/commands
        //returns the created object
        [HttpPost]
        public async Task<ActionResult<CommandReadDTO>> CreateCommand(CommandCreateDTO cmdCreateDTO)
        {
            if (cmdCreateDTO == null) throw new ArgumentNullException(nameof(cmdCreateDTO));
            var command = _mapper.Map<Commands>(cmdCreateDTO);
            await _db.CreateCommandAsync(command);
            await _db.SaveChangesAsync();
            var commandReadDTO = _mapper.Map<CommandReadDTO>(command);
            //return Ok(_mapper.Map<CommandReadDTO>(command));
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO);
        }

        //responds to the put requests with uri: api/commands/id
        //this is inefficient; client must provide the whole object to perform update- prone to error
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, CommandUpdateDTO cmdUpdateDTO)
        {
            var commandToUpdate = await _db.GetCommandByIdAsync(id);
            if (commandToUpdate == null) return NotFound();

            //takes care of updating- hence empty interface implementation
            _mapper.Map(cmdUpdateDTO, commandToUpdate);

            //just in case later in future you need more specific update implementation
            await _db.UpdateCommandAsync(commandToUpdate);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        //responds to the patch requests with uri: api/commands/id
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var commandToUpdate = await _db.GetCommandByIdAsync(id);
            if (commandToUpdate == null) return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandToUpdate);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch, commandToUpdate);

            await _db.UpdateCommandAsync(commandToUpdate);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        //responds to the delete requests with uri: api/commands/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            var commandToDelete = await _db.GetCommandByIdAsync(id);
            if (commandToDelete == null) return NotFound();
            await _db.DeleteCommandAsync(commandToDelete);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
