using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

      
        
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _context.Clientes.ToListAsync();

            var nombrecli = from cli in list
                            select new{ cli.NombeCliente, cli.Telefono} ;

            return  Ok(nombrecli);
        }
    }
}
