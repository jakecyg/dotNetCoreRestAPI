using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.DTOs
{
    public class CommandCreateDTO
    {
        [Required]
        public string ShortCutTo { get; set; }
        [Required]
        public string Command { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
