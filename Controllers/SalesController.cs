using CRM.Context;
using CRM.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Sale> list = _context.Sales.ToList();
            if(list.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Sale sale)
        {
            var costumer = await _context.Costumers.FirstOrDefaultAsync(c => c.Id == sale.CostumerId);

            if (costumer == null)
            {
                return NoContent();
            }

            _context.Sales.Add(sale);

            costumer.NumberSales += sale.Quantity;
            costumer.TotalSalesValue += sale.Quantity * sale.SalesPrice;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, Sale sale)
        {
            var saleDB = _context.Sales.FirstOrDefault(s => s.Id == id);

            if (saleDB == null)
            {
                return NotFound();
            }

            saleDB.BateryType = sale.BateryType;
            saleDB.BateryModel = sale.BateryModel;
            saleDB.Quantity = sale.Quantity;
            saleDB.SalesPrice = sale.SalesPrice;
            saleDB.CostumerId = sale.CostumerId;
            saleDB.Notes = sale.Notes;

            _context.Sales.Update(saleDB);
            _context.SaveChanges();

            return Ok(saleDB);
        }

        [HttpPatch]
        public IActionResult PatchNotes(int id, Sale sale)
        {
            var saleDB = _context.Sales.FirstOrDefault(s => s.Id == id);

            if (saleDB == null)
            {
                return NotFound();
            }

            sale.Notes += " " + saleDB.Notes;

            _context.Sales.Update(saleDB);
            _context.SaveChanges();

            return Ok(saleDB.Notes);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sale = _context.Sales.FirstOrDefault(s => s.Id == id);
            var costumer = _context.Costumers.FirstOrDefault(c => c.Id == sale.CostumerId);

            if (sale == null || costumer == null)
            {
                return NotFound();
            }

            costumer.NumberSales -= sale.Quantity;
            costumer.TotalSalesValue -= sale.Quantity * sale.SalesPrice;

            _context.Sales.Remove(sale);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
