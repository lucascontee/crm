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

        [HttpPost]
        public IActionResult CreateCostumer(Costumer costumer)
        {
            _context.Add(costumer);
            _context.SaveChanges();
            return Ok(costumer);
        }
    }
}
