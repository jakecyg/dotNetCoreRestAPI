using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.DTOs
{
    public class CommandReadDTO
    {
        public int Id { get; set; }
        public string ShortCutTo { get; set; }
        public string Command { get; set; }
        public string Platform { get; set; }
    }
}
