using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nam.BL.Interface;
using Nam.DTO.Dto;

namespace Nam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cartBL;
        public CartController(ICartBL _cartBL)
        {
            cartBL = _cartBL;
        }

        [HttpPost]
        [Route("AddCart")]
        public async Task<bool> AddCart(CartDto input)
        {
            return await cartBL.AddCart(input);
        }

        [HttpGet]
        [Route("User/{UserId}")]
        public async Task<CartDto> GetCartByUserId(long UserId)
        {
            return await cartBL.GetCartByUserId(UserId);
        }

        [HttpDelete]
        public async Task DeleteCart(long UserId)
        {
            await cartBL.DeleteCart(UserId);
        }
    }
}
