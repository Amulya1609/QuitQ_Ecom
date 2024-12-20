﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuitQ_Ecom.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly QuitQEcomContext _context;
        private readonly ILogger<TokenController> _logger;

        public TokenController(IConfiguration configuration, QuitQEcomContext context, IMapper mapper, ILogger<TokenController> logger)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("isauthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = HttpContext.User;
                var userClaimId = user.Claims.FirstOrDefault(c => c.Type == "UserId");
                var userId = int.Parse(userClaimId.Value);
                //var userObj =await _context.Users.FindAsync(userId);
                var userObj = _context.Users.FirstOrDefault(u => u.UserId == userId);


                var userRole = await GetUserRole(userObj.UserTypeId);
                    var userGender = await getUserGender(userObj.GenderId);
                    var userStatus = await getUserStatus(userObj.UserStatusId);
                    var userInfo = new
                    {
                        //contact number
                        //
                        UserId = userObj.UserId,
                        Username = userObj.Username,
                        Email = userObj.Email,
                        UserRole = userRole,
                        Gender = userGender,
                        ContactNumber = userObj.ContactNumber,
                        DateOfBirth = userObj.Dob,
                        FirstName = userObj.FirstName,
                        LastName = userObj.LastName,
                        UserStatus = userStatus
                    };
                
                




                return Ok(new { success = true,userData = userInfo });
            }
            return Ok(new { success = false, userData = "" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(LoginDTO _userData)
        {
            try
            {
                if (_userData != null && _userData.Username != null && _userData.Password != null)
                {
                    var user = await GetUser(_userData.Username, _userData.Password);

                    if (user != null)
                    {
                        var userRole = await GetUserRole(user.UserTypeId);
                        //create claims details based on the user information

                        

                        var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", user.UserId.ToString()),
                            new Claim("UserName", user.Username),
                            new Claim("Email", user.Email),
                            new Claim(ClaimTypes.Role,userRole)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(60),
                            signingCredentials: signIn);

                        var userGender =await getUserGender(user.GenderId);
                        var userStatus =await  getUserStatus(user.UserStatusId);

                        var userInfo = new
                        {
                            //contact number
                            //
                            UserId = user.UserId,
                            Username = user.Username,
                            Email = user.Email,
                            UserRole = userRole,
                            Gender = userGender,
                            ContactNumber = user.ContactNumber,
                            DateOfBirth = user.Dob,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            UserStatus = userStatus
                        };

                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), success = "True" ,userData = userInfo });
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while generating token: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private async Task<string> getUserStatus(int? userStatusId)
        {
            try
            {
                return await _context.UserStatuses.Where(x => x.UserStatusId == userStatusId).Select(x => x.UserStatus1).FirstAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting user role: {ex.Message}");
                return null;
            }
        }

        private async Task<string> getUserGender(int? genderId)
        {
            try
            {
                 return await _context.Genders.Where(x => x.GenderId == genderId).Select(x => x.GenderName).FirstAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting user role: {ex.Message}");
                return null;
            }
        }

        private async Task<UserDTO> GetUser(string username, string password)
        {
            try
            {
                var hashedpassword = UsersController.HashPassword(password);
                var obj = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == hashedpassword);
                return _mapper.Map<UserDTO>(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting user: {ex.Message}");
                return null;
            }
        }

        private async Task<string> GetUserRole(int UsertypeId)
        {
            try
            {
                return await _context.UserTypes.Where(x => x.UserTypeId == UsertypeId).Select(x => x.UserType1).FirstAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting user role: {ex.Message}");
                return null;
            }
        }
    }
}
