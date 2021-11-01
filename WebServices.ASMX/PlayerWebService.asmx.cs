using System;
using System.Collections.Generic;
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
    }
}
