using Entity.DataTransferObjects.Categories;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _manager.CategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute(Name = "categoryId")] int categoryId)
        {
            var category = await _manager.CategoryService.GetCategoryByIdAsync(categoryId, false);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryDtoInsertion categoryDto)
        {
            var category = await _manager.CategoryService.CreateCategoryAsync(categoryDto);
            return StatusCode(201, category);
        }

        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] CategoryDtoUpdate categoryDto, 
            [FromRoute(Name = "categoryId")] int categoryId)
        {
            await _manager.CategoryService.UpdateCategoryAsync(categoryId, false, categoryDto);
            return NoContent();
        }

        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute(Name = "categoryId")] int categoryId)
        {
            await _manager.CategoryService.DeleteCategoryAsync(categoryId, false);
            return NoContent();
        }

    }
}
