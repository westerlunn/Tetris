using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using Infrastructure.Repositories;
using TheGame.EFRepository;

namespace GameWeb.Controllers
{
    [Route("game")]
    public class GameController : Controller
    {
        //private GameStateRepository _gameRepository;

        //protected GameController(GameStateRepository gameRepository)
        //{
        //    _gameRepository = gameRepository;
        //}

        [HttpGet]
        public ActionResult Get()
        {
            //return(OkResult);
            var result = 1;
            return Json(new
            {
                success = true,
                Message = result
            });
        }
    }
}