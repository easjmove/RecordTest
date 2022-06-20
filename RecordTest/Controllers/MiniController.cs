using Microsoft.AspNetCore.Mvc;
using RecordTest.Manager;
using RecordTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecordTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiniController : ControllerBase
    {
        private readonly MiniManager _manager = new();
        // GET: api/<MiniController>
        [HttpGet]
        public IEnumerable<MiniClass> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<MiniController>/5
        [HttpGet("{id}")]
        public ActionResult<MiniRecord> Get(int id)
        {
            MiniClass? foundMini = _manager.GetByID(id);
            if (foundMini != null)
            {
                return Ok(new MiniRecord(foundMini));
            } else
            {
                return NotFound();
            }
            
        }

        // POST api/<MiniController>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<MiniRecord> Post([FromBody] MiniRecord value)
        {
            try
            {
                MiniClass converted = new(value);
                _manager.Add(converted);
                return Created("api/Mini/" + converted.Id, new MiniRecord(converted));
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Not allowed value?: " + ex.Message);
            }
        }
    }
}
