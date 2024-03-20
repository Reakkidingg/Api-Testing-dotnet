using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTestAPI.Models;
using UnitTestAPI.Service;

namespace UnitTestAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetCategory());
        [HttpGet("Id")]
        public async Task<IActionResult> Get(Guid Id)
            => Ok(await _service.GetCategory(Id));

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            if (ModelState.IsValid)
            {
                if(await _service.Save(category))
                {
                    return Created("", category);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Guid Id, Category category)
        {
            if (ModelState.IsValid)
            {
                if(await _service.Update(Id, category))
                {
                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (await _service.Delete(Id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
