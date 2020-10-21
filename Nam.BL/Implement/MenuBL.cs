using AutoMapper;
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
    public class MenuBL : IMenuBL
    {
        private readonly IRepository db;
        public MenuBL(IRepository _db)
        {
            db = _db;
        }

        public async Task<List<MenuDto>> GetAllMenu()
        {
            var list = await db.GetAllAsync<Menu>(u => u.IsDeleted == false);
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.MapperList<Menu, MenuDto>(list.ToList());
        }

        public async Task<MenuDto> InsertOrUpdateMenu(MenuDto input)
        {
            var exist = await db.AnyAsync<Menu>(u => u.Id != input.Id && u.Name == input.Name);
            if (exist)
            {
                throw new Exception(string.Format("Menu {0} already existed", input.Name));
            }
            var item = Nam.ULTILS.AutoMapper.AutoMapperProfile.Mapper<MenuDto, Menu>(input);
            item.SlugUrl = Nam.ULTILS.Slug.Slug.GenerateSlug(input.Name, 200);
            if (input.Id <= 0)
            {
                var rs = await db.AddAsync<Menu>(item);
                input.Id = rs.Id;
            }
            else
            {
                item.ModifiedDate = DateTime.Now;
                await db.UpdateAsync<Menu>(item);
            }
            return input;
        }

        public async Task DeleteMenu(long Id)
        {
            var menu = await db.GetAsync<Menu>(Id);
            try
            {
                if(menu != null)
                {
                    menu.IsDeleted = true;
                    await db.UpdateAsync<Menu>(menu);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
