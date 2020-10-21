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
    public class ProductBL : IProductBL
    {
        private readonly IRepository db;
        public ProductBL(IRepository _db)
        {
            db = _db;
        }


        //Get list product by id group product
        public async Task<List<ProductDto>> GetAllByGroupProductId(long GPId)
        {
            var result = await db.GetAllAsync<Product>(u => u.IsDeleted == false && u.GroupProductId == GPId);
            var sortList = result.OrderByDescending(u => u.Price).ToList();
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.MapperList<Product, ProductDto>(sortList);
        }


        //Get list product by slug url group product
        public async Task<List<ProductDto>> GetAllBySlugGroupProduct(string SlugUrl)
        {
            var gp = db.Get<GroupProduct>(u => u.SlugUrl == SlugUrl);
            var result = await db.GetAllAsync<Product>(u => u.IsDeleted == false && u.GroupProductId == gp.Id);
            var sortList = result.OrderByDescending(u => u.Price).ToList();
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.MapperList<Product, ProductDto>(sortList);
        }


        //Get list product by MenuId
        public async Task<List<ProductDto>> GetAllByMenuId(long MenuId)
        {
            var query = (from p in db.GetAll<Product>(u => u.IsDeleted == false)
                         join gp in db.GetAll<GroupProduct>(u => u.IsDeleted == false) on p.GroupProductId equals gp.Id
                         join m in db.GetAll<Menu>(u => u.IsDeleted == false) on gp.MenuId equals m.Id
                         where m.Id == MenuId
                         select new ProductDto
                         {
                             Id = p.Id,
                             Name = p.Name,
                             Image = p.Image,
                             Price = p.Price,
                             Quantity = p.Quantity,
                             GroupProductId = p.GroupProductId
                         }).ToList();
            return await Task.FromResult(query.ToList());
        }


        //Get list product like name
        public async Task<List<ProductDto>> GetAllLikeName(string Name)
        {
            var result = await db.GetAllAsync<Product>(u => u.IsDeleted == false && u.Name.Contains(Name) );
            var sortList = result.OrderByDescending(u => u.Price).ToList();
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.MapperList<Product, ProductDto>(sortList);
        }

        //Insert or update product
        public async Task<ProductDto> InsertOrUpdateProduct(ProductDto input)
        {
            var exist = await db.AnyAsync<Product>(u => u.Id != input.Id && u.Name == input.Name);
            if (exist)
            {
                throw new Exception(string.Format("Product {0} already existed", input.Name));
            }
            var item = Nam.ULTILS.AutoMapper.AutoMapperProfile.Mapper<ProductDto, Product>(input);
            item.SlugUrl = Nam.ULTILS.Slug.Slug.GenerateSlug(input.Name, 200);
            if (input.Id <= 0)
            {
                var rs = await db.AddAsync<Product>(item);
                input.Id = rs.Id;
            }
            else
            {
                item.ModifiedDate = DateTime.Now;
                await db.UpdateAsync<Product>(item);
            }
            return input;
        }

        //Get list new product sort by date
        public async Task<List<ProductDto>> GetAllNew(int Quantity)
        {
            var list = await db.GetAllAsync<Product>(u => u.IsDeleted == false);
            var result = list.OrderByDescending(u => u.CreatedDate).Take(Quantity).ToList();
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.MapperList<Product, ProductDto>(result);
        }


        //Get list product by slug url
        public async Task<ProductDto> GetBySlugUrl(string Slug)
        {
            var prd = await db.GetAsync<Product>(u => u.SlugUrl == Slug);
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.Mapper<Product, ProductDto>(prd);
        }


        //Delete Product
        public async Task<bool> DeleteProduct(long Id)
        {
            bool result = false;
            var item = await db.GetAsync<Product>(Id);
            try
            {
                if (item != null)
                {
                    item.IsDeleted = true;
                    item.DeletedDate = DateTime.Now;
                    await db.UpdateAsync<Product>(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return result;
        }
    }
}
