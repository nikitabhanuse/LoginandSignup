﻿using LoginandSignup.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginandSignup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserModel userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _authContext.Users.
                FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password == userObj.Password);
            if(user == null)
                return NotFound(new { Message = "User not found!" });
            return Ok(new
            {
                Message = "Login Sucess!"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserModel userObj)
        {
            if (userObj == null)
                return BadRequest();

            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registerred"
            });

        }

    }
}
