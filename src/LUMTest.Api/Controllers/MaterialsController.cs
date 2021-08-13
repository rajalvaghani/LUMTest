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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaterialQuery>> Get([FromRoute] Guid id)
        {
            var material = await _materialService.Get(id.ToString());
            if (material == null)
                return NotFound();
            var materialQuery = new MaterialQuery(material);
            return Ok(materialQuery);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaterialQuery>> Create([FromBody] MaterialCommand request)
        {

            MaterialFunction materialFunction = null;
            if (request.MaterialFunction != null)
            {
                if (request.MaterialFunction.MinTemperature > request.MaterialFunction.MaxTemperature)
                {
                    ModelState.AddModelError("minTemperature", "Minimum temperature must not be higher than maximum temperature");
                    return BadRequest(ModelState);
                }

                materialFunction = new MaterialFunction(request.MaterialFunction.MinTemperature, request.MaterialFunction.MaxTemperature);
            }

            var material = new Material(null, request.Name, request.IsVisible, request.TypeOfPhase, materialFunction);
            var addedMaterial = await _materialService.Insert(material);

            if (addedMaterial == null)
                return BadRequest();

            return CreatedAtAction(nameof(Create), new { id = addedMaterial.Id }, new MaterialQuery(addedMaterial));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaterialQuery>> Update([FromRoute] Guid id, [FromBody] MaterialCommand request)
        {
            //Check Document is exists with the given id
            var isExists = await _materialService.ElementExists(id.ToString());
            if (!isExists)
                return NotFound();

            MaterialFunction materialFunction = null;

            if (request.MaterialFunction != null)
            {
                if (request.MaterialFunction.MinTemperature > request.MaterialFunction.MaxTemperature)
                {
                    ModelState.AddModelError("minTemperature", "Minimum temperature must not be higher than maximum temperature");
                    return BadRequest(ModelState);
                }

                materialFunction = new MaterialFunction(request.MaterialFunction.MinTemperature, request.MaterialFunction.MaxTemperature);
            }

            var material = new Material(id.ToString(), request.Name, request.IsVisible, request.TypeOfPhase, materialFunction);
            var updatedmaterial = await _materialService.Update(material);

            if (updatedmaterial == null)
                return NotFound();

            return Ok(new MaterialQuery(updatedmaterial));
        }
    }
}
