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
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL orderBL;
        public OrderController(IOrderBL _orderBL)
        {
            orderBL = _orderBL;
        }

        [HttpGet]
        [Route("User={UserId}")]
        public async Task<List<OrderDto>> GetAllByUserId(long UserId)
        {
            return await orderBL.GetAllByUserId(UserId);
        }


        [HttpPost] 
        [Route("AddOrder")]
        public async Task<bool> AddOrder(long UserId)
        {
            return await orderBL.AddOrder(UserId);
        }

        [HttpGet]
        [Route("Detail={Id}")]
        public async Task<List<OrderDetailDto>> GetAllDetailById(long Id)
        {
            return await orderBL.GetAllDetailById(Id);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<bool> DeleteOrder(long Id)
        {
            return await orderBL.DeleteOrder(Id);
        }

        [HttpPost]
        [Route("DeleteDetail")]
        public async Task<bool> DeleteOrderDetail(long ODId)
        {
            return await orderBL.DeleteOrderDetail(ODId);
        }
    }
}
