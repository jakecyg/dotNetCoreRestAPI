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
    interface ICommandsRepo
    {
        IEnumerable<Commands> GetCommands();
    }
}
