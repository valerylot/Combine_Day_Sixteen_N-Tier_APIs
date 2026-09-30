
using Combine_Day_Sixteen_N_Tier_APIs.Dtos;
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
        public ActionResult<List<SupplyReadDTO>> GetAll()
        {
            return Ok(_supplies.GetAll()); //returns Ok 200 + list of supplies
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult<SupplyReadDTO> GetById(int id)
        {   
            //we are returning our DTO, NOT our model because we do not want the location leaking
            SupplyReadDTO? supply = _supplies.GetById(id);
            
            //if no supply with that id is available, we return 404
            if(supply == null)
            {
                return NotFound($"No supply with ID: {id}");
            }
            return Ok(supply); //200
        }

        // [APIController] checks the DTOs attributes [Required] & [Range] BEFORE the method runs
        // any no name or any bad quantity, the user gets an automatic 400
        [HttpPost("create")]
        public ActionResult<SupplyReadDTO> Create([FromBody]SupplyCreateDTO supply)
        {
            SupplyReadDTO? created = _supplies.Create(supply);

            if(created == null)
            {
                //this is stating there is a conflict with the information that sent and the DB 
                return Conflict($"There is already a supply called {supply.Name}"); //409 status code
            }

            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created);

        }

        [HttpPut("{id}/Withdraw/{amount}")]
        public ActionResult<SupplyReadDTO> Withdraw(int id, int amount)
        {
            SupplyReadDTO? supply = _supplies.GetById(id);

            if(supply == null)
            {
                return NotFound($"No supply with ID: {id}");
            }

            bool ok = _supplies.Withdraw(id, amount);

            if(ok == false)
            {
                return BadRequest($"Can't withdraw {amount}. There are {supply.Quantity} on the shelf.");
            }

            return Ok(true);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
          

            if(_supplies.GetById(id) == null)
            {
                return NotFound($"No supply with an ID {id}");
            }
            _supplies.Delete(id);
            return NoContent();
        }
        
    }
}