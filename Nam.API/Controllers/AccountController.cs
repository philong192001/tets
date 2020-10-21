using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nam.BL.Interface;
using Nam.DAL.Repositories;
using Nam.DTO.Dto;
using Nam.EFCore;
using Nam.EFCore.Entities;
using Unity;

namespace Nam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBL accountBL;
        public AccountController(IAccountBL _accountBL)
        {
            accountBL = _accountBL;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<UserInfoDto>> GetAll()
        {
            return await accountBL.GetAllUser();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<UserLoginDto> Login(UserDto input)
        {
            return await accountBL.Login(input);
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<UserLoginDto> Register(UserRegisterDto input)
        {
            return await accountBL.Register(input);
        }

        [HttpGet]
        [Route("User/Id={UserId}")]
        [AllowAnonymous]
        public async Task<UserInfoDto> GetUserById(long UserId)
        {
            return await accountBL.GetUserById(UserId);
        }
    }
}
