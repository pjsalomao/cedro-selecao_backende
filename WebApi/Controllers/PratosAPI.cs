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
    [Route("api/PratosAPI")]
    public class PratosAPI : Controller
    {
        private readonly RestauranteContext _context;

        public PratosAPI(RestauranteContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Prato> GetAll()
        {
            return _context.Pratos.ToList();
        }

        // GET api/<controller>/{id}
        [HttpGet("{id}", Name = "GetPrato")]
        public IActionResult GetById(int id)
        {
            var item = _context.Pratos.FirstOrDefault(t => t.PratoID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Prato prato)
        {
            if (prato == null)
            {
                BadRequest();
            }

            _context.Pratos.Add(prato);
            _context.SaveChanges();

            CreatedAtRoute("GetPrato", new { id = prato.PratoID }, prato);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Prato prato)
        {
            if (prato == null || prato.PratoID != id)
            {
                BadRequest();
            }

            var prat = _context.Pratos.FirstOrDefault(t => t.PratoID == id);
            if (prat == null)
            {
                NotFound();
            }

            //todo.IsComplete = item.IsComplete;
            prat.PratoNome = prato.PratoNome;
            prat.Preco = prato.Preco;
            

            _context.Pratos.Update(prat);
            _context.SaveChanges();
            new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var prat = _context.Pratos.FirstOrDefault(t => t.PratoID == id);
            if (prat == null)
            {
                NotFound();
            }

            _context.Pratos.Remove(prat);
            _context.SaveChanges();
            new NoContentResult();
        }
    }
}
