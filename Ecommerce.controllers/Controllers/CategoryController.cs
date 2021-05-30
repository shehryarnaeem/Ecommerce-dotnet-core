using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.models;
using Ecommerce.services.interfaces;
using Ecommerce.services;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.controllers.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Category>> GetCategorys()
        {
            IEnumerable<Category> categories = this._categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            Category category = this._categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost("")]
        public ActionResult<Category> PostCategory(Category newCategory)
        {
            Category category = new Category();
            category = newCategory;
            this._categoryService.Create(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category updatedCategory)
        {
            Category category = this._categoryService.GetById(id);
            category = updatedCategory;
            this._categoryService.Update(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategoryById(int id)
        {
            this._categoryService.Delete(id);
            return Ok();
        }
    }
}