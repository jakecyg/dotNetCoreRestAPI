using dotNetCoreRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.Data
{
    public class DbRepo : ICommandsRepo
    {
        private readonly dotNetCoreRestAPIContext _context;
        //db context dependency injection
        public DbRepo(dotNetCoreRestAPIContext context) => _context = context;

        public IEnumerable<Commands> GetAllCommands() => _context.Commands.ToList();
        public Commands GetCommandById(int id) => _context.Commands.FirstOrDefault(x => x.Id == id);
        public void CreateCommand(Commands cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            _context.Add(cmd);
        }
        public void UpdateCommand(Commands cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
        }
        public bool SaveChanges() => _context.SaveChanges() >= 0;

        public void DeleteCommand(Commands cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            _context.Commands.Remove(cmd);
        }
    }
}
