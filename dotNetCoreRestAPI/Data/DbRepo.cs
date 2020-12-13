using dotNetCoreRestAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        //public IEnumerable<Commands> GetAllCommands() => _context.Commands.ToList();
        public async Task<IEnumerable<Commands>> GetAllCommandsAsync() => await _context.Commands.ToListAsync();

        public async Task<Commands> GetCommandByIdAsync(int id) => await _context.Commands.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<bool> CreateCommandAsync(Commands cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            await _context.Commands.AddAsync(cmd);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        public async Task<bool> UpdateCommandAsync(Commands cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            _context.Commands.Update(cmd);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteCommandAsync(Commands cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            _context.Commands.Remove(cmd);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;

        }
        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() >= 0;

    }
}
