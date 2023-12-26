using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Einkaufszettel.Domain;
using Einkaufszettel.Repository;

namespace Einkaufszettel.View.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly EinkaufContext _context;

        public ProduktController(EinkaufContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produkt>> Get()
        {
            return _context.Produkte;
        }

        [HttpGet("{id}")]
        public ActionResult<Produkt> Get(string id)
        {
            var produkt = _context.Produkte.Find(id);

            if (produkt == null)
            {
                return NotFound();
            }

            return produkt;
        }
    }

}
