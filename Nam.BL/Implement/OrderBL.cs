using Microsoft.EntityFrameworkCore;
using Nam.BL.Interface;
using Nam.DAL.Repositories;
using Nam.DTO.Dto;
using Nam.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nam.BL.Implement
{
    public class OrderBL : IOrderBL
    {
        private readonly IRepository db;
        public OrderBL(IRepository _db)
        {
            db = _db;
        }
        public async Task<List<OrderDto>> GetAllByUserId(long UserId)
        {
            var list = (from o in db.GetAll<Order>(u => u.UserId == UserId && u.IsDeleted == false)
                        join od in db.GetAll<OrderDetail>() on o.Id equals od.OrderId into orderDetail
                        select new OrderDto
                        {
                            Id = o.Id,
                            UserId = o.UserId,
                            Address = o.Address,
                            Status = o.Status,
                            PayType = o.PayType,
                            CreatedDate = o.CreatedDate,
                            Total = orderDetail.Sum(u => u.Amount)
                        }).ToList();
            return await Task.FromResult(list);
        }

        public async Task<bool> AddOrder(long UserId)
        {
            bool result = false;
            var cart = await db.GetAsync<Cart>(u => u.IsDeleted == false && u.UserId == UserId);
            Order inputOrder = new Order
            {
                UserId = UserId
            };
            try
            {
                var order = await db.AddAsync<Order>(inputOrder);
                var listCD = (from cd in db.GetAll<CartDetail>(u => u.IsDeleted == false)
                              join prd in db.GetAll<Product>(u => u.IsDeleted == false) on cd.ProductId equals prd.Id
                              where cd.CartId == cart.Id
                              select new OrderDetail
                              {
                                  ProductId = cd.ProductId,
                                  OrderId = order.Id,
                                  Quantity = cd.Quantity,
                                  Amount = cd.Quantity * prd.Price
                              }).ToList();
                foreach (var cd in listCD)
                {
                    await db.AddAsync<OrderDetail>(cd);
                }
                result = true;
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format(ex.ToString()));
            }
            return result;
        }

        public async Task<bool> DeleteOrder(long Id)
        {
            bool result = false;
            var order = await db.GetAsync<Order>(u => u.IsDeleted == false && u.Id == Id);
            if(order != null)
            {
                order.IsDeleted = true;
                order.DeletedDate = DateTime.Now;
                try
                {
                    await db.UpdateAsync<Order>(order);
                    result = true;
                }
                catch(Exception ex)
                {
                    throw new Exception(string.Format(ex.ToString()));
                }
            }
            return result;
        }

        public async Task<List<OrderDetailDto>> GetAllDetailById(long Id)
        {
            var orderDetail = await db.GetAllAsync<OrderDetail>(u => u.OrderId == Id);
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.MapperList<OrderDetail, OrderDetailDto>(orderDetail.ToList());
        }

        public async Task<bool> DeleteOrderDetail(long ODId)
        {
            bool result = false;
            var orderDetail = await db.GetAsync<OrderDetail>(u => u.Id == ODId);
            if(orderDetail != null)
            {
                try
                {
                    await db.DeleteAsync<OrderDetail>(ODId);
                    result = true;
                }
                catch(Exception ex)
                {
                    throw new Exception(string.Format(ex.ToString()));
                }
            }
            return result;
        }
    }
}
