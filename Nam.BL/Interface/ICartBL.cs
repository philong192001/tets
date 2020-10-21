using Nam.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nam.BL.Interface
{
    public interface ICartBL
    {
        Task<bool> AddCart(CartDto input);

        Task DeleteCart(long CartId);

        Task<CartDto> GetCartByUserId(long UserId);
    }
}
