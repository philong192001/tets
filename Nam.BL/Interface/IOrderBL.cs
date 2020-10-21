using Nam.DTO.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nam.BL.Interface
{
    public interface IOrderBL
    {
        Task<List<OrderDto>> GetAllByUserId(long UserId);
        Task<bool> AddOrder(long UserId);

        Task<List<OrderDetailDto>> GetAllDetailById(long Id);

        Task<bool> DeleteOrder(long Id);

        Task<bool> DeleteOrderDetail(long ODId);
    }
}
