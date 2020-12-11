using dotNetCoreRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.Data
{
    /// <summary>
    /// Will not be used to connect to db; for hard coded testing
    /// </summary>
    public class MockCommandsRepo : ICommandsRepo
    {
        public Commands GetCommandById(int id) =>  new Commands { Id = 0, ShortCutTo = "test1" , Command = "command1", Platform = "platform1" };

        public IEnumerable<Commands> GetAllCommands()
        {
            var commands = new List<Commands>
            {
                new Commands { Id = 0, ShortCutTo = "test1", Command = "command1", Platform = "platform1" },
                new Commands { Id = 1, ShortCutTo = "test2", Command = "command2", Platform = "platform2" },
                new Commands { Id = 2, ShortCutTo = "test3", Command = "command3", Platform = "platform3" },
            };
            return commands;
        }
    }
}
