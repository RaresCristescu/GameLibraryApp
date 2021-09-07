using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.DTOs;
using RealGames.Models;
using RealGames.Repositories.DeveloperRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        public IDeveloperRepository IDeveloperRepository { get; set; }
        public DeveloperController(IDeveloperRepository repository)
        {
            IDeveloperRepository = repository;
        }
        // GET: api/<ArtistController>
        [HttpGet]
        public ActionResult<IEnumerable<Developer>> Get()
        {
            return IDeveloperRepository.GetAll();
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public ActionResult<Developer> Get(int id)
        {
            return IDeveloperRepository.Get(id);
        }


        // POST api/<ArtistController>
        [HttpPost]
        public Developer Post(DeveloperDTO value)
        {
            Developer model = new Developer()
            {
                Name = value.Name,
                Website = value.Website,
                Country = value.Country
            };
            return IDeveloperRepository.Create(model);
        }

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public Developer Put(int id, DeveloperDTO value)
        {
            Developer model = IDeveloperRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Website != null)
            {
                model.Website = value.Website;
            }
            if (value.Country != null)
            {
                model.Country = value.Country;
            }
            return IDeveloperRepository.Update(model);
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public Developer Delete(int id)
        {
            Developer developer = IDeveloperRepository.Get(id);
            return IDeveloperRepository.Delete(developer);
        }
    }
}