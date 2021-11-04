using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebServices.Data.Model;

namespace WebServices.RESTAPI.Controllers
{
    public class PlayerController : ApiController
    {
        FootballPlayersConnection db = new FootballPlayersConnection();

        // GET api/player
        public IEnumerable<Player> Get()
        {
            return db.Player;
        }

        // GET api/player/5
        public Player Get(int id)
        {
            return db.Player.FirstOrDefault(x => x.Id == id);
        }

        // POST api/player
        public bool Post([FromBody] Player sentPlayer)
        {
            db.Player.Add(sentPlayer);
            db.SaveChanges();
            return true;
        }

        // PUT api/player/5
        public bool Put(int id, [FromBody] Player sentPlayer)
        {
            if (id != sentPlayer.Id)
            {
                return false;
            }

            db.Entry(sentPlayer).State = EntityState.Modified;

            db.SaveChanges();
            return true;
        }

        // DELETE api/player/5
        public IHttpActionResult Delete(int id)
        {
            Player player = db.Player.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Player.Remove(player);
            db.SaveChanges();

            return Ok();
        }
    }
}