using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LUMTest.Api.Models;
using LUMTest.Domain;
using LUMTest.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LUMTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MaterialQuery>>> GetAll()
        {
            var materials = await _materialService.GetAll();
            if (!materials.Any())
                return NotFound();
            return Ok(materials.Select(m => new MaterialQuery(m)));
        }

    }
}
