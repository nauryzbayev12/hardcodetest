using AutoMapper;
using Catalog.Core.DTOs;
using Catalog.Core.Services.Implementation;
using Catalog.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
   
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUploadService _uploadService;

        public ProductController( ILogger<ProductController> logger,
            IMapper mapper,
            IProductService productService,
            IUploadService uploadService)
        {
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
            _uploadService = uploadService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO dTO)
        {
            if (dTO == null) return BadRequest();

            var result = await _productService.Insert(dTO);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO dTO)
        {
            if (dTO == null) return BadRequest();

            var result = await _productService.Update(dTO);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null) return BadRequest();

            var result = await _productService.Delete((int)id);

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = _productService.GetAll();

            return Ok(await result.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null) return BadRequest();

            var result = await _productService.Find((int)id);

            return Ok(result);
        }

        [HttpGet] 
        public IActionResult GetImageById(int id)
        {
            var filePath = _uploadService.GetImagePath(id);
            if (filePath == null) return NotFound();
            return PhysicalFile(filePath, "image/png");
        }
    }
}
