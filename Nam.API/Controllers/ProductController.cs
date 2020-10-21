using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nam.BL.Interface;
using Nam.DTO.Dto;
using Nam.EFCore.Entities;

namespace Nam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL productBL;
        public ProductController(IProductBL _productBL)
        {
            productBL = _productBL;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ProductDto>> GetAllByGroupProductId(long GPId)
        {
            return await productBL.GetAllByGroupProductId(GPId);
        }

        [HttpGet("{SlugMenu}")]
        [AllowAnonymous]
        public async Task<List<ProductDto>> GetAllBySlugGroupProduct(string SlugMenu)
        {
            return await productBL.GetAllBySlugGroupProduct(SlugMenu);
        }

        [HttpGet]
        [Route("Name={Name}")]
        [AllowAnonymous]
        public async Task<List<ProductDto>> GetAllLikeName(string Name)
        {
            return await productBL.GetAllLikeName(Name);
        }

        [HttpGet]
        [Route("New={Quantity}")]
        [AllowAnonymous]
        public async Task<List<ProductDto>> GetAllNew(int Quantity)
        {
            return await productBL.GetAllNew(Quantity);
        }

        [HttpGet]
        [Route("Detail={Slug}")]
        [AllowAnonymous]
        public async Task<ProductDto> GetBySlugUrl(string Slug)
        {
            return await productBL.GetBySlugUrl(Slug);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ProductDto> Save(ProductDto input)
        {
            return await productBL.InsertOrUpdateProduct(input);
        }
    }
}
