using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SvelteAspNetCoreApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IActionResult GetAll()
        {
            var result = new List<object>{
                new
                {
                    Name ="Ahmet",
                    Surname ="KANDEMİR"
                },
                new {
                    Name ="İsmail",
                    Surname ="ŞEN"
                },
                new {
                    Name ="Hasan",
                    Surname ="ÇEVİK"
                },
                new {
                    Name ="Ali",
                    Surname ="ERKURAN"
                },
                new {
                    Name ="Mehmet",
                    Surname ="TÜTEN"
                },
                new {
                    Name ="Yavuz",
                    Surname ="ÖZTÜRK"
                },

            };

            return Ok(result);
        }
    }
}
