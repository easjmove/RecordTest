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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<MiniRecord>> Get()
        {
            IEnumerable<MiniClass> list = _manager.GetAll();
            if (list != null && list.Any())
            {
                List<MiniRecord> result = new();
                foreach (MiniClass miniClass in list)
                {
                    result.Add(new MiniRecord(miniClass));
                }
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<MiniController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<MiniRecord> Get(int id)
        {
            MiniClass? foundMini = _manager.GetByID(id);
            if (foundMini != null)
            {
                return Ok(new MiniRecord(foundMini));
            }
            else
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
