using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nam.BL.Interface;
using Nam.DTO.Dto;

namespace Nam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupProductController : ControllerBase
    {
        private readonly IGroupProductBL groupProductBL;
        public GroupProductController(IGroupProductBL _groupProductBL)
        {
            groupProductBL = _groupProductBL;
        }

        [HttpGet("{SlugMenu}")]
        public async Task<List<GroupProductDto>> GetAllBySlugMenu(string SlugMenu)
        {
            return await groupProductBL.GetAllBySlugMenu(SlugMenu);
        }
    }
}
