using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealGames.DTOs;
using RealGames.Models;
using RealGames.Repositories.BundleRepository;
using RealGames.Repositories.GameBundleRepository;
using RealGames.Repositories.GameRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BundleController : ControllerBase
    {
        public IBundleRepository IBundleRepository { get; set; }
        public IGameBundleRepository IGameBundleRepository { get; set; }
        public IGameRepository IGameRepository { get; set; }

        public BundleController(IBundleRepository bundlerepository, IGameBundleRepository gamebundlerepository, IGameRepository gamerepository)
        {
            IBundleRepository = bundlerepository;
            IGameBundleRepository = gamebundlerepository;
            IGameRepository = gamerepository;
        }
        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<Bundle>> Get()
        {
            return IBundleRepository.GetAll();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public BundleDetailsDTO Get(int id)
        {
            Bundle Bundle = IBundleRepository.Get(id);
            BundleDetailsDTO MyBundle = new BundleDetailsDTO()
            {
                Name = Bundle.Name,
                Price = Bundle.Price
            };
            IEnumerable<GameBundle> MyGameBundles = IGameBundleRepository.GetAll().Where(x => x.BundleId == Bundle.Id);
            if (MyGameBundles != null)
            {
                List<string> GameNameList = new List<string>();
                foreach (GameBundle MyGameBundle in MyGameBundles)
                {
                    Game MyGame = IGameRepository.GetAll().SingleOrDefault(x => x.Id == MyGameBundle.GameId);
                    GameNameList.Add(MyGame.Name);
                }
                MyBundle.GameName = GameNameList;
            }
            return MyBundle;
        }
        // POST api/<SongController>
        [HttpPost]
        public void Post(BundleDTO value)
        {
            Bundle model = new Bundle
            {
                Name = value.Name,
                Price = value.Price
            };
            IBundleRepository.Create(model);
            for (int i = 0; i < value.GameId.Count; i++)
            {
                GameBundle GameBundle = new GameBundle()
                {
                    BundleId = model.Id,
                    GameId = value.GameId[i]
                };
                IGameBundleRepository.Create(GameBundle);
            }
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Put(int id, BundleDTO value)
        {
            Bundle model = IBundleRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Price != 0)
            {
                model.Price = value.Price;
            }
            IBundleRepository.Update(model);
            if (value.GameId != null)
            {
                IEnumerable<GameBundle> MyGameBundles = IGameBundleRepository.GetAll().Where(x => x.BundleId == id);
                foreach (GameBundle MyGameBundle in MyGameBundles)
                {
                    IGameBundleRepository.Delete(MyGameBundle);
                }
                for (int i = 0; i < value.GameId.Count; i++)
                {
                    GameBundle GameBundle = new GameBundle()
                    {
                        BundleId = model.Id,
                        GameId = value.GameId[i]
                    };
                    IGameBundleRepository.Create(GameBundle);
                }
            }
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public Bundle Delete(int id)
        {
            Bundle model = IBundleRepository.Get(id);
            return IBundleRepository.Delete(model);
        }
    }
}
