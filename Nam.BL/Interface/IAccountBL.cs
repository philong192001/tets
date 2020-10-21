using DTO.UserDto;
using Nam.DTO.Dto;
using Nam.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nam.BL.Interface
{
    public interface IAccountBL
    {
        Task<UserLoginDto> Login(UserDto input);

        Task<List<UserInfoDto>> GetAllUser();

        Task<UserLoginDto> Register(UserRegisterDto input);

        Task<UserInfoDto> GetUserById(long UserId);
    }
}
