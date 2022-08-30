using AirlineApp.Repository.Model;
using AirlineApp.Services.Admin;
using ApnaAahar.Services;
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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IAuthenticationService _authenticationService;

        public AdminController(IAdminService adminService, IAuthenticationService authenticationService)
        {
            _adminService = adminService;
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(User user)
        {
            User tokenData = new User();
            try
            {
                tokenData = await _authenticationService.Authenticate(user);
                if (tokenData == null)
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(tokenData);
        }

        [HttpPost("AddPassenger")]
        public async Task<bool> AddPassenger(Passenger passenger)
        {
            try
            {
                return (await _adminService.AddPassenger(passenger));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("UpdatePassenger")]
        public async Task<bool> UpdatePassenger(Passenger passenger)
        {
            try
            {
                return (await _adminService.UpdatePassenger(passenger));
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [HttpPost("DeleteAndUpdateServices")]
        public async Task<bool> DeleteAndUpdateServices(Passenger passenger)
        {
            try
            {
                return (await _adminService.DeleteAndUpdateServices(passenger));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
