using Nam.DTO.Dto;
using Nam.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nam.BL.Interface
{
    public interface IMenuBL
    {
        Task<List<MenuDto>> GetAllMenu();

        Task<MenuDto> InsertOrUpdateMenu(MenuDto input);

        Task DeleteMenu(long Id);
    }
}
