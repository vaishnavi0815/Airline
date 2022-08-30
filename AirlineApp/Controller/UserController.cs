using AirlineApp.Repository.Model;
using AirlineApp.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<bool> Register(User user)
        {
            bool isUserValid;
            try
            {
                isUserValid = await _userService.AddStaffRegistrationDetails(user); 
            }
            catch (Exception)
            {

                throw;
            }
            return isUserValid;
        }
    }
}
