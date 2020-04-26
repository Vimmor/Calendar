using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WeatherApi.EventData.EventContext;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        private static DataContext context = new DataContext();


    }
}