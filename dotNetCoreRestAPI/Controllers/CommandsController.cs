using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCoreRestAPI.Controllers
{
    //ApiController = provides some out of the box functionalities
    [ApiController]
    public class CommandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
