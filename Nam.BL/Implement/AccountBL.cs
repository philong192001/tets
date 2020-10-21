using AutoMapper;
using DTO.UserDto;
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
    public class AccountBL : IAccountBL
    {
        private readonly IRepository db;
        public AccountBL(IRepository _db)
        {
            db = _db;
        }

        public async Task<UserLoginDto> Login(UserDto input)
        {
            string hashPass = Nam.ULTILS.Encrypts.EncryptMD5.CreateMD5(input.Password);
            var user = await db.GetAsync<User>(u => u.UserName == input.UserName && u.PassWord == hashPass && u.IsDeleted == false);
            var result = new UserLoginDto();
            if(user != null)
            {
                result.UserName = user.UserName;
                result.Email = user.Email;
                result.Token = Nam.ULTILS.JWTToken.AuthenticationToken.CreateJWTToken(user);
            }
            else
            {
                result = null;
            }
            return result;
        }

        public async Task<List<UserInfoDto>> GetAllUser()
        {
            var list = await db.GetAllAsync<User>(u => u.IsActive == true && u.IsDeleted == false);
            return ULTILS.AutoMapper.AutoMapperProfile.MapperList<User, UserInfoDto>(list.ToList());
        }

        public async Task<UserLoginDto> Register(UserRegisterDto input)
        {
            var exist = await db.AnyAsync<User>(u => u.UserName == input.UserName);
            if (exist)
            {
                throw new Exception(string.Format("User {0} already existed", input.UserName));
            }

            User user = new User
            {
                UserName = input.UserName,
                PassWord = input.Password,
                Email = input.Email
            };
            var userLogin = new UserLoginDto();
            try
            {
                await db.AddAsync<User>(user);
                userLogin.UserName = user.UserName;
                userLogin.Email = user.Email;
                userLogin.Token = Nam.ULTILS.JWTToken.AuthenticationToken.CreateJWTToken(user);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return userLogin;
        }

        public async Task<UserInfoDto> GetUserById(long UserId)
        {
            var user = await db.GetAsync<User>(u => u.IsActive == true && u.IsDeleted == false && u.Id == UserId);
            return Nam.ULTILS.AutoMapper.AutoMapperProfile.Mapper<User, UserInfoDto>(user);
        }
    }
}
