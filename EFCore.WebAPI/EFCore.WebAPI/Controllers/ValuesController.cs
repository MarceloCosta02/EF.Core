using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            // LINQ METHOD's
            var listHeroi = _context.Herois.ToList();

            // LINQ QUERY's
            // var listHeroi = (from hero in _context.Herois 
            //                   select heroi).ToList();

            return Ok(listHeroi);
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult GetByName(string nome)
        {
            var listHeroi = _context.Herois
                            .Where(h => h.Nome.Contains(nome))
                            .ToList();
            return Ok(listHeroi);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois
                                .Where(h => h.Id == id)
                                .Single();

            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}
