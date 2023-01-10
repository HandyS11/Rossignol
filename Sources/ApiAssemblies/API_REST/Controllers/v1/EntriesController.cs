﻿using ApiEntities;
using Microsoft.AspNetCore.Mvc;

namespace API_REST.Controllers.V1
{
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public class EntriesController : ControllerBase
    {
        public IActionResult Get(int page = 1)
        {
            return StatusCode(501);
        }

        public IActionResult Post([FromBody] EntryEntity entry)
        {
            return StatusCode(501);
        }

        public IActionResult Put(string id, [FromBody] EntryEntity entry)
        {
            return StatusCode(501);
        }

        public IActionResult Delete(string id)
        {
            return StatusCode(501);
        }
    }
}