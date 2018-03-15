using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using restaurante_backend.Data;
using restaurante_backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteAPI : Controller
    {
        private readonly RestauranteContext _context;

        public RestauranteAPI(RestauranteContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Restaurante> GetAll()
        {
            return _context.Restaurantes.ToList();
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetRestaurante")]
        public IActionResult GetById(int id)
        {
            var item = _context.Restaurantes.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Restaurante restaurante)
        {
            if (restaurante == null)
            {
                BadRequest();
            }

            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();

            CreatedAtRoute("GetRestaurante", new { id = restaurante.ID }, restaurante);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Restaurante restaurante)
        {
            if (restaurante == null || restaurante.ID != id)
            {
                BadRequest();
            }

            var rest = _context.Restaurantes.FirstOrDefault(t => t.ID == id);
            if (rest == null)
            {
                NotFound();
            }

            //todo.IsComplete = item.IsComplete;
            rest.RestauranteNome = restaurante.RestauranteNome;

            _context.Restaurantes.Update(rest);
            _context.SaveChanges();
            new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rest = _context.Restaurantes.FirstOrDefault(t => t.ID == id);
            if (rest == null)
            {
                NotFound();
            }

            _context.Restaurantes.Remove(rest);
            _context.SaveChanges();
            new NoContentResult();
        }
    }
}
