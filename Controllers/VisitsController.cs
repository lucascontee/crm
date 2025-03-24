using CRM.Context;
using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Visit> list = _context.Visits.ToList();

            if (list.Count == 0) return BadRequest();

            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post(Visit visit)
        {
            var costumer = _context.Costumers.FirstOrDefault(c => c.Id == visit.CostumerId);

            if (costumer == null)
            {
                return BadRequest();
            }

            _context.Visits.Add(visit);

            costumer.NumberVisits += 1;

            _context.SaveChanges();
            return Ok(visit);
        }

        [HttpPut]
        public IActionResult Put(int id, Visit visit)
        {
            var visitDB = _context.Visits.FirstOrDefault(c => c.Id == id);

            if(visitDB == null) return BadRequest();

            visitDB.VisitDate = visit.VisitDate;
            visitDB.Notes = visit.Notes;

            _context.SaveChanges();

            return Ok(visitDB);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var visit = _context.Visits.FirstOrDefault(v => v.Id == id);
            
            if (visit == null) return BadRequest();

            var costumer = _context.Costumers.FirstOrDefault(c => c.Id == visit.CostumerId);

            if (costumer == null) return BadRequest(); 
 
            costumer.NumberVisits -= 1;

            _context.Remove(visit);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
