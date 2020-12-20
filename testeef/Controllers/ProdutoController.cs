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
    [Route("v1/produto")]
    public class ProdutoController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produto = await context.produtos.Include(x => x.category).ToListAsync();
            return produto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produto = await context.produtos.Include(x => x.category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.id == id);       

            return produto;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetByCategory([FromServices] DataContext context, int id)
        {
            var produto = await context.produtos.Include(x => x.category).Where(x => x.CategoryId == id).ToListAsync();
            return produto;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post(
            [FromServices] DataContext context, 
            [FromBody] Produto model)
        {
            if(ModelState.IsValid)
            {
                context.produtos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else{return BadRequest(ModelState);}
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> Put([FromServices] DataContext context, [FromBody] Produto produto, int id)
        {
            if(produto.id != id)
            {
                return BadRequest();                
            }

            context.Entry(produto).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return produto;           
        }
        
    }
}