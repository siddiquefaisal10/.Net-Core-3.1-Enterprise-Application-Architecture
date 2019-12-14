using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwinCityCoders.API.Extensions;
using TwinCityCoders.Services.Test;

namespace TwinCityCoders.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController,Authorize]
    public class TestController : APIControllerExtention
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            var token = _testService.Login();
            return Ok(token);
        }        
        
        
        [HttpGet]
        public IActionResult DecodeToken()
        {
            var data = GetProfile();
            return Ok(data);
        }        
        
        [HttpGet]
        public IActionResult DataFromLinqQuery()
        {
            var dbData = _testService.DbLinq();
            return Ok(dbData);
        }        
        
        
        [HttpGet]
        public IActionResult DataFromSp()
        {
            var spData = _testService.SpQuery();
            return Ok(spData);
        }


    }
}