﻿using dotNetCoreRestAPI.Data;
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
        //Inject dependency
        public CommandsController(ICommandsRepo dn) => _db = dn;

        //respond to HttpGet requests with uri: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Commands>> GetAllCommands()
        {
            var commands = _db.GetCommands();
            //return 200 success
            return Ok(commands);
        }

        //respond to get requests with uri: api/commands/id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Commands>> GetComandById(int id)
        {
            var command = _db.GetCommandById(id);
            return Ok(command);

        }
    }
}
