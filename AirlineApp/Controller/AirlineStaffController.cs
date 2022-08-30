using AirlineApp.Repository.Model;
using AirlineApp.Services.Admin;
using AirlineApp.Services.AirlineStaff;
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
    public class AirlineStaffController : ControllerBase
    {
        private readonly IAirlineStaffService _airlineStaffService;

        public AirlineStaffController(IAirlineStaffService airlineStaffService)
        {
            _airlineStaffService = airlineStaffService;
        }

        [HttpGet("GetPassengers")]
        public async Task<ActionResult<List<Passenger>>> GetPassengers()
        {
            try
            {
                return Ok(await _airlineStaffService.GetPassengers());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
