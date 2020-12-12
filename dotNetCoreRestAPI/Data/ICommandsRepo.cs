using dotNetCoreRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.Data
{
    /// <summary>
    /// RestAPI interfaces
    /// </summary>
    public interface ICommandsRepo
    {
        bool SaveChanges();
        //Get all
        IEnumerable<Commands> GetAllCommands();
        //Get one
        Commands GetCommandById(int id);
        //Create command
        void CreateCommand(Commands cmd);
        //Update command
        void UpdateCommand(Commands cmd);
        //Delete command
        void DeleteCommand(Commands cmd);
    }
}
