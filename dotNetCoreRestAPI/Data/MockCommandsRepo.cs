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

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Commands>> GetAllCommandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Commands> GetCommandByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCommandAsync(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCommandAsync(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCommandAsync(Commands cmd)
        {
            throw new NotImplementedException();
        }
    }
}
