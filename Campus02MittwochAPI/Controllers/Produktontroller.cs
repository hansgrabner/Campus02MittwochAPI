using Campus02MittwochAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campus02MittwochAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        static List<Produkt> productList;

        static ProduktController()
        {
            productList = new List<Produkt>();
        }
        // GET: api/<Lektor>
        [HttpGet]
        public List<Produkt> Get()
        {
            return productList;
        }

        // GET api/<Lektor>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Produkt gefunden = null;
            foreach (Produkt forEachVariable in productList)
            {
                if (forEachVariable.Id==id)
                {
                    gefunden = forEachVariable;
                }
            }
            if (gefunden == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(gefunden);
            }       
        }
        [HttpPost]
        public ActionResult Post([FromBody] Produkt value)
        {
            if (value.Preis < 0)
                return BadRequest();

            value.Id = productList.Count + 1;
            productList.Add(value);

            return CreatedAtAction("Get",new {id = value.Id});
        }

        // PUT api/<Lektor>/5
        [HttpPut("{id}")]
        public Produkt Put(int id, [FromBody] Produkt value)
        {
            var produkt = productList.Where(l => l.Id == id).FirstOrDefault();
            produkt.Bezeichnung = value.Bezeichnung;
            produkt.Preis = value.Preis;
            return produkt;
        }

        // DELETE api/<Lektor>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var produkt = productList.Where(l => l.Id == id).FirstOrDefault();
            productList.Remove(produkt);
        }
    }
}
