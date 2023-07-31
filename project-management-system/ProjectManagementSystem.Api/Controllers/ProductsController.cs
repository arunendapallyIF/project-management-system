using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using ProjectManagementSystem.Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productservice)
        {
            _productService=productservice;
        }
        // GET: api/<ProductsController>
        [HttpGet, Route("v1/product")]
        public async Task<ActionResult> Get()
        {

            var productList= _productService.GetProducts();
            return Ok(productList);
        }
        // GET: api/<ProductsController>
        [HttpGet, Route("v1/product/{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                Guard.ArgumentNotNullOrEmpty(id, "id should not be null");
                var productList = await _productService.GetProduct(id);
                return Ok(productList);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
     
        // POST api/<ProductsController>
        [HttpPost, Route("v1/product")]
        public async Task<ActionResult> AddProduct([FromBody] UserProduct userProduct)
        {
            if(userProduct != null)
            {
                return Ok(await _productService.AddProduct(userProduct));
            }
            return BadRequest();
        }

        // PUT api/<ProductsController>/5
        [HttpPut, Route("v1/product/{id}")]
        public async Task<ActionResult> UpdateProduct(string id, [FromBody] UserProduct userProduct)
        {
            if (userProduct != null)
            {
                Guard.ArgumentNotNullOrEmpty(id, "ProductID should not be null");
                Guard.ArgumentNotNullOrEmpty(userProduct?.ProductId, "ProductID should not be null");
                var result = await _productService.UpdateProduct(id, userProduct);
                return Ok(result);
            }
            return BadRequest();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete, Route("v1/product/{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            Guard.ArgumentNotNullOrEmpty(id, "id should not be null");
            var result=await  _productService.DeleteProduct(id);
            return Ok(result);
        }
    }
}
