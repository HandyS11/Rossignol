﻿using API_REST.Services;
using ApiEntities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_REST.Controllers.V1
{
    [ApiController]
    [Route("/api/v{version:apiVersion}/accounts")]
    public class AccountsController : ControllerBase
    {
        private IAccountServices services;

        [HttpGet("{id}")]
        public IActionResult GetUserInfo(string id)
        {
            var user = services.GetUser(id);
            if (user == null) return NotFound();
            else return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AccountEntity account)
        {
            var user = services.GetUserByEmail(account.Email);
            if (user != null) return Conflict("This email already has an account");
            bool succeeded = services.AddUser(account);
            if (succeeded)
            {
                var url = $"{Request.Scheme}://{Request.Host}/api/v1/accounts/{account.Id}";
                return Created(url, services.GetUser(account.Id));
            }
            else return StatusCode(500);
        }

        [HttpPut("{id}")]
        public IActionResult ChangeUserInfo(string id, [FromBody] AccountEntity account)
        {
            var user = services.GetUser(id);
            if (user == null) return NotFound("Account does not exist");
            user = services.GetUserByEmail(account.Email);
            if (user != null) return Conflict("This email is already associated with another accout");
            bool succeeded = services.UpdateUser(id, account);
            return succeeded ? NoContent() : StatusCode(500);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            bool succeeded = services.DeleteUser(id);
            return succeeded ? NoContent() : NotFound();
        }
    }
}
