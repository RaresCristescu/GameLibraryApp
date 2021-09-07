using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.DTOs;
using RealGames.Models;
using RealGames.Repositories.CategoryRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryRepository ICategoryRepository { get; set; }

        public CategoryController(ICategoryRepository repository)
        {
            ICategoryRepository = repository;
        }
        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return ICategoryRepository.GetAll();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return ICategoryRepository.Get(id);
        }

        // POST api/<SongController>
        [HttpPost]
        public Category Post(CategoryDTO value)
        {
            Category model = new Category
            {
                Name = value.Name
            };
            return ICategoryRepository.Create(model);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public Category Put(int id, CategoryDTO value)
        {
            Category model = ICategoryRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            return ICategoryRepository.Update(model);
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public Category Delete(int id)
        {
            Category model = ICategoryRepository.Get(id);
            return ICategoryRepository.Delete(model);
        }
    }
}
