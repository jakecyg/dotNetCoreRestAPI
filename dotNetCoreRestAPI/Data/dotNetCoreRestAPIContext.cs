using dotNetCoreRestAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.Data
{
    public class dotNetCoreRestAPIContext : DbContext
    {
        //
        public dotNetCoreRestAPIContext(DbContextOptions<dotNetCoreRestAPIContext> option) : base(option)
        {
        }

        //Create representation of the Commands model in the databse; i.e. mapping to database
        public DbSet<Commands> Commands { get; set; }
    }
}
