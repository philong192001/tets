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
    public class GroupProductBL : IGroupProductBL
    {
        private readonly IRepository db;
        public GroupProductBL(IRepository _db)
        {
            db = _db;
        }

        public async Task<List<GroupProductDto>> GetAllByMenuId(long MenuId)
        {
            var list =  await db.GetAllAsync<GroupProduct>(u => u.IsDeleted == false && u.MenuId == MenuId);
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.MapperList<GroupProduct, GroupProductDto>(list.ToList());
        }

        public async Task<List<GroupProductDto>> GetAllBySlugMenu(string SlugMenu)
        {
            var menu = db.Get<Menu>(u => u.SlugUrl == SlugMenu);
            var list = await db.GetAllAsync<GroupProduct>(u => u.IsDeleted == false && u.MenuId == menu.Id);
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.MapperList<GroupProduct, GroupProductDto>(list.ToList());
        }

        public async Task<GroupProductDto> InsertOrUpdateGroupProduct(GroupProductDto input)
        {
            var exist = await db.AnyAsync<GroupProduct>(u => u.Id != input.Id && u.Name == input.Name);
            if (exist)
            {
                throw new Exception(string.Format("Menu {0} already existed", input.Name));
            }
            var item = Nam.ULTILS.AutoMapper.AutoMapperProfile.Mapper<GroupProductDto, GroupProduct>(input);
            item.SlugUrl = Nam.ULTILS.Slug.Slug.GenerateSlug(input.Name, 200);
            if (input.Id <= 0)
            {
                var rs = await db.AddAsync<GroupProduct>(item);
                input.Id = rs.Id;
            }
            else
            {
                item.ModifiedDate = DateTime.Now;
                await db.UpdateAsync<GroupProduct>(item);
            }
            return input;
        }
    }
}
