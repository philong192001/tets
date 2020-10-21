using Nam.DTO.Dto;
using Nam.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nam.BL.Interface
{
    public interface IGroupProductBL
    {
        Task<List<GroupProductDto>> GetAllByMenuId(long MenuId);

        Task<List<GroupProductDto>> GetAllBySlugMenu(string SlugMenu);
    }
}
