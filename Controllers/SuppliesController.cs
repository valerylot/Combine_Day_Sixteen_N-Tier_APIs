
using Combine_Day_Sixteen_N_Tier_APIs.Models;
using Combine_Day_Sixteen_N_Tier_APIs.Services;
using Microsoft.AspNetCore.Mvc;

namespace Combine_Day_Sixteen_N_Tier_APIs.Controllers
{
    [ApiController]
    [Route("[controller]")] // /supplies
    public class SuppliesController : ControllerBase
    {
        private readonly ISupplyService _supplies;

        public SuppliesController(ISupplyService supplies)
        {
            _supplies = supplies;
        }

        [HttpGet("getall")]
        public ActionResult<List<Supply>> GetAll()
        {
            return Ok(_supplies.GetAll()); //returns Ok 200 + list of supplies
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult<Supply> GetById(int id)
        {
            Supply? supply = _supplies.GetById(id);
            
            //if no supply with that id is available, we return 404
            if(supply == null)
            {
                return NotFound($"No supply with ID: {id}");
            }
            return Ok(supply); //200
        }

        [HttpPost("create")]
        public ActionResult<Supply> Create([FromBody]Supply supply)
        {
            Supply? created = _supplies.Create(supply);

            if(created == null)
            {
                return BadRequest("A supply needs a name and its quantity cannot be below 0");
            }

            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created);

        }

        [HttpPut("{id}/Withdraw/{amount}")]
        public ActionResult<Supply> Withdraw(int id, int amount)
        {
            Supply? supply = _supplies.GetById(id);

            if(supply == null)
            {
                return NotFound($"No supply with ID: {id}");
            }

            bool ok = _supplies.Withdraw(supply, amount);

            if(ok == false)
            {
                return BadRequest($"Can't withdraw {amount}. There are {supply.Quantity} on the shelf.");
            }

            return Ok(supply);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Supply? supply = _supplies.GetById(id);

            if(supply == null)
            {
                return NotFound($"No supply with an ID {id}");
            }
            _supplies.Delete(supply);
            return NoContent();
        }
    }
}