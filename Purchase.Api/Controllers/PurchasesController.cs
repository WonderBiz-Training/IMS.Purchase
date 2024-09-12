using Microsoft.AspNetCore.Mvc;
using Purchase.Application.Interfaces;
using static Purchase.Application.DTOs.PurchaseDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Purchase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchasesServices _purchasesServices;

        public PurchasesController(IPurchasesServices purchasesServices)
        {
            _purchasesServices = purchasesServices;
        }

        // GET: api/<PurchaseHeadersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPurchasesDto>>> Get()
        {
            try
            {
                var res = await _purchasesServices.GetAllPurchasesAsync();

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<PurchaseHeadersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPurchasesDto>> Get(Guid id)
        {
            try
            {
                var res = await _purchasesServices.GetPurchaseByIdAsync(id);

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<PurchaseHeadersController>
        [HttpPost]
        public async Task<ActionResult<GetPurchasesDto>> Post([FromBody] CreatePurchasesDto purchases)
        {
            try
            {
                var res = await _purchasesServices.CreatePurchaseAsync(purchases);

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<PurchaseHeadersController>
        [HttpPost(nameof(PostDetailed))]
        public async Task<ActionResult<GetPurchasesDto>> PostDetailed([FromBody] CreateDetailedPurchaseDto purchases)
        {
            try
            {
                var res = await _purchasesServices.CreateDetailedPurchaseAsync(purchases);

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/<PurchaseHeadersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetPurchasesDto>> Put(Guid id, [FromBody] UpdatePurchasesDto purchases)
        {
            try
            {
                var res = await _purchasesServices.UpdatePurchaseAsync(id, purchases);

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<PurchaseHeadersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                var res = await _purchasesServices.DeletePurchaseAsync(id);

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
