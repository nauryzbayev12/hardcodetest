using AutoMapper;
using Catalog.Core.DTOs;
using Catalog.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
   
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly ILogger<ProductTypeController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(ILogger<ProductTypeController> logger,
            IMapper mapper,
            IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductType(CreateProductTypeDTO dTO)
        {
            if (dTO == null) return BadRequest();

            var result = await _productTypeService.Insert(dTO);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductType(UpdateProductTypeDTO dTO)
        {
            if (dTO == null) return BadRequest();

            var result = await  _productTypeService.Update(dTO);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductType(int? id)
        {
            if (id == null) return BadRequest();

            var result = await _productTypeService.Delete((int)id);

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetProductTypes()
        {
            var result =  _productTypeService.GetAll();

            return Ok(await result.ToListAsync());
        }
        [HttpGet] 
        public async Task<IActionResult> GetProductType(int? id)
        {
            if(id == null) return BadRequest();

            var result = await _productTypeService.Find((int)id);

            return Ok(result);
        }

    }
}
