﻿using ApiEntities;
using Microsoft.AspNetCore.Mvc;

namespace API_REST.Controllers.V1
{
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public class SharedEntriesController : ControllerBase
    {
        public IActionResult Get(string id, int page = 1)
        {
            return StatusCode(501);
        }

        public IActionResult Post(string id, [FromBody] SharedEntryEntity entry)
        {
            return StatusCode(501);
        }

        public IActionResult Delete(string id, [FromBody] string userId)
        {
            return StatusCode(501);
        }
    }
}