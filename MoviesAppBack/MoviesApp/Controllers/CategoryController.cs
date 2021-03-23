
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Core.Entities;
using MoviesApp.Core.Interfaces;
using MoviesApp.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Controllers
{
   
    public class CategoryController : AbstractAPIController
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet("Categories")]
        public IEnumerable<CategoryListingModel> Categories()
        {
            var model = _categoryRepo.GetCategories().Select(p => new CategoryListingModel { 
               CategoryId=p.CategoryId,
               name=p.name
            });
            return model;
        }
        
       
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryCreateModel category)
        {
            var model = new Category {
             CategoryId = Guid.NewGuid().ToString(),
             name=category.name
            };
           await _categoryRepo.add(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<CategoryIndexModel> Category(string id)
        {
            var model = await _categoryRepo.GetCategory(id);
            if (model == null) return null;
            var user = new CategoryIndexModel { 
                 CategoryId=model.CategoryId,
                 name=model.name
            };

            return user;
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await _categoryRepo.GetCategory(id);
            if (model == null) return NotFound();

           await _categoryRepo.delete(model);
            return Ok();
        }

       
        [HttpPut("update")]
        public async Task<IActionResult> update(CategoryUpdateModel category)
        {
            var Item =await _categoryRepo.GetCategory(category.CategoryId);
            if (Item == null) return NotFound();
            var model = new Category {
                CategoryId=category.CategoryId,
                name=category.name
            };
           await _categoryRepo.update(model);
            return Ok();
        }


    }
}
