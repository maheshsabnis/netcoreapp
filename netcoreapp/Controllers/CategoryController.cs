using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcoreapp.Models;
using netcoreapp.Services; 
namespace netcoreapp.Controllers
{
    [Route("api/[controller]")] // route expression
    [ApiController] // the attribute for API Execution
    // 1. Detect the Request Type [GET/POST/PUT/DELETE]
    // 2. Check for Security from Request Headers
    // 3. Read the Posted data from Body (default)/ URL/QUERYSTRING
    // 4. Execute REST API
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category, int> catRepository;
        /// <summary>
        /// Inject the CategoryRepository
        /// </summary>
        public CategoryController(IRepository<Category, int> catRepository)
        {
            this.catRepository = catRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cats = catRepository.GetAsync().Result;
            return Ok(cats);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cat = catRepository.GetAsync(id).Result;
            return Ok(cat);
        }
        [HttpPost]
        public IActionResult Post(Category category)
        {
            if (ModelState.IsValid)
            {
                category = catRepository.CreateAsync(category).Result;
                return Ok(category);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                category = catRepository.UpdateAsync(id, category).Result;
                return Ok(category);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = catRepository.DeleteAsync(id).Result;
            if(res) return Ok(res);
            return NotFound($"Resource based on {id} is not found");

        }

    }
}