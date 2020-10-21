using Nam.DTO.Dto;
using Nam.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nam.BL.Interface
{
    public interface IProductBL
    {
        Task<List<ProductDto>> GetAllByGroupProductId(long GPId);

        Task<List<ProductDto>> GetAllBySlugGroupProduct(string SlugUrl);

        Task<List<ProductDto>> GetAllByMenuId(long MenuId);

        Task<List<ProductDto>> GetAllLikeName(string Name);

        Task<List<ProductDto>> GetAllNew(int Quantity);

        Task<ProductDto> GetBySlugUrl(string Slug);

        Task<ProductDto> InsertOrUpdateProduct(ProductDto input);

        Task<bool> DeleteProduct(long Id);

    }
}
