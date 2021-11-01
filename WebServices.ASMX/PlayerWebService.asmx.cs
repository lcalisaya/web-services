using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServices.Data.Model;

namespace WebServices.ASMX
{
    /// <summary>
    /// Summary description for PlayerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PlayerWebService : System.Web.Services.WebService
    {
        FootballPlayersConnection db = new FootballPlayersConnection();

        [WebMethod]
        public List<Player> GetPlayers()
        {
            return db.Player.ToList();
        }

        [WebMethod]
        public Player GetPlayer(int id)
        {
            return db.Player.FirstOrDefault(x => x.Id == id);
        }

        [WebMethod]
        public Player AddPlayer(string fname, string lname, DateTime birth, string origin, string genre, string clubnow)
        {
            Player newPlayer = new Player() { FirstName = fname,
                                              LastName = lname,
                                              BirthDate = birth,
                                              Nationality = origin,
                                              Genre = genre,
                                              ActualClub = clubnow };

            Player player = db.Player.Add(newPlayer);
            db.SaveChanges();
            return player;
        }


        [WebMethod]
        public Player UpdatePlayer(int id, string fname, string lname, DateTime birth, string origin, string genre, string clubnow)
        {
            Player playerInDB = GetPlayer(id);
            playerInDB.FirstName = fname;
            playerInDB.LastName = lname;
            playerInDB.Genre = genre;
            playerInDB.ActualClub = clubnow;
            playerInDB.BirthDate = birth;
            playerInDB.Nationality = origin;

            db.Entry(playerInDB).State = EntityState.Modified;

            db.SaveChanges();
            return playerInDB;
        }

        [WebMethod]
        public List<Player> DeletePlayer(int id)
        {
            var player = db.Player.FirstOrDefault(x => x.Id == id);
            if (player != null)
            {
                db.Player.Remove(player);
                db.SaveChanges();
            }

            return GetPlayers();
        }
    }
}
