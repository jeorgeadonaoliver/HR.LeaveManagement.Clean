﻿using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Identity.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveMangement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request) 
        {
            return Ok(await authService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegistrationRequest request)
        {
            return Ok(await authService.Register(request));
        }
    }
}
