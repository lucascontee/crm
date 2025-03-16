using CRM.Context;
using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostumersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CostumersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Costumer> list = _context.Costumers.ToList();
            if (list == null)
            {
                return NoContent();
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var costumer = _context.Costumers.FirstOrDefault(c => c.Id == id);

            if (costumer == null)
            {
                return BadRequest();
            }

            return Ok(costumer);
        }

        [HttpPost]
        public IActionResult Post(Costumer costumer)
        {
            _context.Add(costumer);
            _context.SaveChanges();
            return Ok(costumer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Costumer costumer)
        {
            var costumerDB = _context.Costumers.FirstOrDefault(c => c.Id == id);

            if (costumerDB == null)
            {
                return NotFound();
            }

            costumerDB.StoreName = costumer.StoreName;
            costumerDB.FirstName = costumer.FirstName;
            costumerDB.LastName = costumer.LastName;
            costumerDB.Address = costumer.Address;
            costumerDB.Region = costumer.Region;
            costumerDB.Phone = costumer.Phone;
            costumerDB.MainInformation = costumer.MainInformation;

            _context.Costumers.Update(costumerDB);
            _context.SaveChanges();

            return Ok(costumerDB);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var costumer = _context.Costumers.FirstOrDefault(c => c.Id == id);

            if(costumer == null)
            {
                return NotFound();
            }

            _context.Costumers.Remove(costumer);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
