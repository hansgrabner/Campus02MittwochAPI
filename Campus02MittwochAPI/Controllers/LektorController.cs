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
        [Route("/version1/NBLektoren")]
        public List<Lektor> Get()
        {
            return lektorList;
        }

        [HttpGet]
        [Route("/version1/NBLektorenMitWebSeriviceBezug")]
        public List<Lektor> GetWebServices()
        {
            return lektorList;
        }

        [HttpGet]
        [Route("/SimpleDaten")]
        public void DemoV1(int i, string j, bool b, string vorname)
        {

        }
        public class MyRequestClass
        {
            public int i { get; set; }
            public string j { get; set; }
            public bool b { get; set; }
            public string vorname { get; set; }
        }

        [HttpGet]
        [Route("ComplexerRequest")]
        public void Demo2(MyRequestClass myRequest)
        {
           // myRequest.i;
        }
        // GET api/<Lektor>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Lektor gefunden = new Lektor();
            foreach (Lektor forEachVariable in lektorList)
            {
                if (forEachVariable.LektorId==id)
                {
                    gefunden = forEachVariable;
                }
            }

            if (gefunden.LektorId == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(gefunden);
            }
            
         //   return lektorList.Where( l => l.LektorId==id ).FirstOrDefault();
        }
        /*
        Use helper extension methods like
- GET: OK(object), NotFound()
-POST: BadRequest()
- CreatedAtAction(“Get“, new {id=12});
        */
        // POST api/<Lektor>
        [HttpPost]
        public IActionResult Post([FromBody] Lektor lektor)
        {
            if (lektor.Nachname=="X")
            {
                return BadRequest();
            }

            lektor.LektorId = lektorList.Count + 1;
            lektorList.Add(lektor);

            return Ok(lektor);
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
