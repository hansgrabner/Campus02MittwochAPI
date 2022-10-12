using Campus02MittwochAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campus02MittwochAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LektorController : ControllerBase
    {
        static List<Lektor> lektorList;

        static LektorController()
        {
            lektorList = new List<Lektor>();
        }
        // GET: api/<Lektor>
        [HttpGet]
        public List<Lektor> Get()
        {
            return lektorList;
        }

        // GET api/<Lektor>/5
        [HttpGet("{id}")]
        public Lektor Get(int id)
        {
            Lektor gefunden = new Lektor();
            foreach (Lektor forEachVariable in lektorList)
            {
                if (forEachVariable.LektorId==id)
                {
                    gefunden = forEachVariable;
                }
            }

            return gefunden;
         //   return lektorList.Where( l => l.LektorId==id ).FirstOrDefault();
        }

        // POST api/<Lektor>
        [HttpPost]
        public void Post([FromBody] Lektor value)
        {
            value.LektorId = lektorList.Count + 1;
            lektorList.Add(value);
        }

        // PUT api/<Lektor>/5
        [HttpPut("{id}")]
        public Lektor Put(int id, [FromBody] Lektor value)
        {
            var lektor = lektorList.Where(l => l.LektorId == id).FirstOrDefault();
            lektor.Vorname = value.Vorname;
            return lektor;
        }

        // DELETE api/<Lektor>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var lektor = lektorList.Where(l => l.LektorId == id).FirstOrDefault();
            lektorList.Remove(lektor);
        }
    }
}
