using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPatternSession07.ApplicationServices.Dtos;
using RepositoryDesignPatternSession07.ApplicationServices.Services.Contracts;


namespace RepositoryDesignPatternSession07.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // Sets the base URL to /api/Products
    public class ProductsController : ControllerBase
    {
        // 1. We declare a dependency on the SERVICE INTERFACE, not the DbContext.
        private readonly IProductApplicationService _productService;

        // 2. The service is injected here by the ASP.NET Core framework.
        public ProductsController(IProductApplicationService productService)
        {
            _productService = productService;
        }


        // --- CREATE ---
        // Handles POST requests to /api/products
        [HttpPost]
        public IActionResult Create([FromBody] PostProductDto postDto)
        {
            // The controller's job is simple: delegate to the service.
            _productService.PostProductDto(postDto);

            // A 201 Created response is standard for a successful creation.
            // In a real API, you might also return a URL to the new product.
            return StatusCode(201, new { message = "Product created successfully." });
        }

        // --- READ (All) ---
        // Handles GET requests to /api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products); // Return 200 OK with the list of product DTOs
        }

        // --- READ (By ID) ---
        // Handles GET requests to /api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var product = _productService.GetById(id);

            // If the service returns null, the product wasn't found.
            if (product == null)
            {
                return NotFound(); // Return a standard 404 Not Found
            }

            return Ok(product); // Return 200 OK with the product DTO
        }

        // --- UPDATE ---
        // Handles PUT requests to /api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateProductDto updateDto)
        {
            // A simple validation to ensure the ID in the URL matches the one in the body.
            if (id != updateDto.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }

            try
            {
                _productService.UpdateProductDto(updateDto);
                return NoContent(); // A 204 No Content is standard for a successful update.
            }
            catch (KeyNotFoundException ex)
            {
                // If the service tells us the product doesn't exist, return a 404.
                return NotFound(ex.Message);
            }
        }

        // --- DELETE ---
        // Handles DELETE requests to /api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _productService.Delete(id);
            return NoContent(); // A 204 No Content is standard for a successful delete.
        }
    }
}
