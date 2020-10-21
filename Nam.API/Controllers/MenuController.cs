using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nam.BL.Interface;
using Nam.DTO.Dto;
using Nam.EFCore.Entities;

namespace Nam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuBL menuBL;
        public MenuController(IMenuBL _menuBL)
        {
            menuBL = _menuBL;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<List<MenuDto>> GetAll()
        {
            return await menuBL.GetAllMenu();
        }

        [HttpPost]
        public async Task<MenuDto> InsertOrUpdateMenu(MenuDto input)
        {
            return await menuBL.InsertOrUpdateMenu(input);
        }

        [HttpPost]
        public async Task DeleteMenu(long Id)
        {
            await menuBL.DeleteMenu(Id);
        }
    }
}
