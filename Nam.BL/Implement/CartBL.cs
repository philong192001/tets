using Microsoft.EntityFrameworkCore;
using Nam.BL.Interface;
using Nam.DAL.Repositories;
using Nam.DTO.Dto;
using Nam.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nam.BL.Implement
{
    public class CartBL : ICartBL
    {
        private readonly IRepository db;
        public CartBL(IRepository _db)
        {
            db = _db;
        }

        public async Task<bool> AddCart(CartDto input)
        {
            bool result = false;
            var exist = await db.GetAsync<Cart>(u => u.UserId == input.UserId && u.IsDeleted == false);
            Cart cart = new Cart
            {
                UserId = input.UserId
            };
            if (exist == null)
            {
                cart.CreatedDate = DateTime.Now;
                var item = await db.AddAsync<Cart>(cart);
                cart.Id = item.Id;
            }
            else
            {
                exist.ModifiedDate = DateTime.Now;
                cart.Id = exist.Id;
                await db.UpdateAsync<Cart>(exist);

            }
            foreach(var cd in input.CartDetails)
            {
                var product = await db.GetAsync<Product>(u => u.Id == cd.ProductId && u.IsDeleted == false);
                if (product.Quantity < cd.Quantity)
                {
                    throw new Exception(string.Format("Số lượng sản phẩm không đủ"));
                }
                if (cd.Quantity <= 0)
                {
                    throw new Exception(string.Format("Thêm vào giỏ hàng thất bại"));
                }
                var existCartDetail = await db.GetAsync<CartDetail>(u => u.ProductId == cd.ProductId);
                if(existCartDetail != null)
                {
                    existCartDetail.Quantity += cd.Quantity;
                    await db.UpdateAsync<CartDetail>(existCartDetail);
                }
                else
                {
                    CartDetail cartDetail = new CartDetail
                    {
                        CartId = cart.Id,
                        ProductId = cd.ProductId,
                        Quantity = cd.Quantity,
                        CreatedDate = DateTime.Now
                    };
                    await db.AddAsync<CartDetail>(cartDetail);
                }
                result = true;
            }
            return result;
        }

        public async Task<CartDto> GetCartByUserId(long UserId)
        {
            var cart = (from c in db.GetAll<Cart>(u => u.IsDeleted == false)
                        join cd in db.GetAll<CartDetail>(u => u.IsDeleted == false) on c.Id equals cd.CartId into cartDetail
                        where c.UserId == UserId
                        select new CartDto
                        {
                            Id = c.Id,
                            UserId = c.UserId,
                            CartDetails = cartDetail.OrderByDescending(u => u.CreatedDate)
                            .Join(db.GetAll<Product>(p => p.IsDeleted == false), a => a.ProductId, b => b.Id,
                            (a, b) => new
                            {
                                ProductId = b.Id,
                                Price = b.Price,
                                Quantity = a.Quantity,
                                ProductImage = b.Image,
                                ProductName = b.Name
                            }).Select(u => new CartDetailDto
                            {
                                ProductId = u.ProductId,
                                Quantity = u.Quantity,
                                Amount = u.Quantity*u.Price,
                                ProductImage = u.ProductImage,
                                ProductName = u.ProductName
                            }).ToList()
                        });
            return await Task.FromResult(cart.SingleOrDefault());
        }

        public async Task DeleteCart(long CartId)
        {
            var cart = await db.GetAsync<Cart>(u => u.Id == CartId && u.IsDeleted == false);
            if(cart != null)
            {
                await db.DeleteAsync<Cart>(CartId);
            }
        }
    }
}
