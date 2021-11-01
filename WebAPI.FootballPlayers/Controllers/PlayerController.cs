using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.FootballPlayers.Models;

namespace WebAPI.FootballPlayers.Controllers
{
    public class PlayerController : ApiController
    {
        MiConexion db = new MiConexion();

        // GET api/values
        public IEnumerable<Player> Get()
        {
            return db.Player.ToList();
        }
    }
}