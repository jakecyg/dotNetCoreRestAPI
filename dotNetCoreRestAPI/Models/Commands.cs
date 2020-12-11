using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.Models
{
    public class Commands
    {
        public int Id { get; set; }
        public string ShortCut { get; set; }
        public string CommandLine { get; set; }
        public  string Platform { get; set; }

    }
}
