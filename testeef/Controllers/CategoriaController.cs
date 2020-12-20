using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;


namespace testeef.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categoria = await context.categories.ToListAsync();
            return categoria;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromServices] DataContext context, [FromBody] Category model)
        {
            if(ModelState.IsValid)
            {
                context.categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else{return BadRequest(ModelState);}
        }

        
    }
}