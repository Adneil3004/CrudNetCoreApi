using System.Linq;
using System.Threading.Tasks;
using CrudApi.Data;
using CrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Controllers
{ 
    [ApiController]
    [Route("Api/[controller]")]

    public class ClienteController:ControllerBase
    {
        private readonly DataContext _context;
        public ClienteController (DataContext context)
        {
            _context = context;
        }
        
        //GET api/Cliente
        [HttpGet]
        public async Task<IActionResult> datosClientes() 
        {
            var list = await _context.Clientes.ToListAsync();

            return  Ok(list);
        }

        //GET api/Cliente/5
        [HttpGet("{Id}")]
         public async Task<IActionResult> datosCliente(int id) 
        {
            var list = await _context.Clientes.FirstAsync(x => x.id == id);      
            return  Ok(list);
        }

        [HttpPost("nuevocliente")]
        public async Task<IActionResult> nuevocliente ([FromBody] Dtos.NuevoClientDto client)
        {
            var NewClient  = new Cliente();

            NewClient.NombeCliente = client.NombeCliente.ToUpper();
            NewClient.Telefono = client.Telefono;
            NewClient.Direccion = client.Direccion.ToUpper();
            NewClient.RFC = client.RFC.ToUpper();

            await _context.Clientes.AddAsync(NewClient);
            await _context.SaveChangesAsync();

            var newclient = await _context.Clientes.OrderByDescending(x => x.id).FirstOrDefaultAsync();
            return Ok(newclient);

        }


         [HttpPut("{id}")]
        public async Task<IActionResult> actualizacliente ([FromBody] Dtos.NuevoClientDto client, int id)
        {
            var NewClient  = await _context.Clientes.FirstAsync(x => x.id == id);

            NewClient.NombeCliente = client.NombeCliente.ToUpper();
            NewClient.Telefono = client.Telefono;
            NewClient.Direccion = client.Direccion.ToUpper();
            NewClient.RFC = client.RFC.ToUpper();

            //await _context.Entry(NewClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return StatusCode(201);

        }
    }
}