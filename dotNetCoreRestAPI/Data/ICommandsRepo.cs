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
        Task<bool> SaveChangesAsync();
        //Get all
        Task<IEnumerable<Commands>> GetAllCommandsAsync();
        //Get one
        Task<Commands> GetCommandByIdAsync(int id);
        //Create command
        Task<bool> CreateCommandAsync(Commands cmd);
        //Update command
        Task<bool> UpdateCommandAsync(Commands cmd);
        //Delete command
        Task<bool> DeleteCommandAsync(Commands cmd);
    }
}
