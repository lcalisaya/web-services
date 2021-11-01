using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebServices.Data.Model;

namespace WebServices.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        FootballPlayersConnection db = new FootballPlayersConnection();
        public List<Player> GetPlayers()
        {
            return db.Player.ToList();
        }

        public Player GetPlayer(int id)
        {
            return db.Player.FirstOrDefault(x => x.Id == id);
        }

        public Player AddPlayer(string fname, string lname, DateTime birth, string origin, string genre, string clubnow)
        {
            Player newPlayer = new Player()
            {
                FirstName = fname,
                LastName = lname,
                BirthDate = birth,
                Nationality = origin,
                Genre = genre,
                ActualClub = clubnow
            };

            Player player = db.Player.Add(newPlayer);
            db.SaveChanges();
            return player;
        }

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
