using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Campus02MittwochAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudierendeController : ControllerBase
    {
        //static == Klassenvariable 
        static List<string> meineStudierenden;

        //Klassenkonstruktur -wird NUR einmal aufgerufen -  default init
        static StudierendeController()
        {
            meineStudierenden = new List<string>();
            meineStudierenden.Add("Daniel");
            meineStudierenden.Add("Theresa");

        }

        [HttpGet]
        public List<string> GetVorname()
        {                  
            return meineStudierenden;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
       
        public string Get(int id)
        {
            return meineStudierenden[id];
        }

        [HttpPost]
        public IActionResult Add([FromBody] string vorname)
        {
            meineStudierenden.Add(vorname);
            return Created("https://localhost:7202/api/Studierende", new { id = meineStudierenden.Count -1 });
        }

        [HttpPut("{id}")]

        //Studierende/2
        public void Put(int id, [FromBody] string vorname)
        {
            meineStudierenden[id] = vorname;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            meineStudierenden.RemoveAt(id);
        }
    }
}
