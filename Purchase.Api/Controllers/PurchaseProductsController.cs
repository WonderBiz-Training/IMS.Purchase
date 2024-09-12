using Microsoft.AspNetCore.Mvc;
using Purchase.Application.Interfaces;
using static Purchase.Application.DTOs.PurchaseProductDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Purchase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseProductsController : ControllerBase
    {
        private readonly IPurchaseProductsServices _purchaseServices;

        public PurchaseProductsController(IPurchaseProductsServices purchaseServices)
        {
            _purchaseServices = purchaseServices;
        }

        // GET: api/<PurchasesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPurchaseProductsDto>>> Get()
        {
            try
            {
                var res = await _purchaseServices.GetPurchasesAsync();

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/<PurchasesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPurchaseProductsDto>> Get(Guid id)
        {
            try
            {
                var res = await _purchaseServices.GetPurchaseByIdAsync(id);

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<PurchasesController>
        [HttpPost]
        public async Task<ActionResult<GetPurchaseProductsDto>> Post([FromBody] CreatePurchaseProductsDto purchase)
        {
            try
            {
                var res = await _purchaseServices.CreatePurchaseAsync(purchase);

                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/<PurchasesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetPurchaseProductsDto>> Put(Guid id, [FromBody] UpdatePurchaseProductsDto purchase)
        {
            try
            {
                var res = await _purchaseServices.UpdatePurchaseAsync(id, purchase);
                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<PurchasesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                var res = await _purchaseServices.DeletePurchaseAsync(id);
                return Ok(res);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
