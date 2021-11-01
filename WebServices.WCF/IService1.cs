using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebServices.Data.Model;

namespace WebServices.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Player> GetPlayers();

        [OperationContract]
        Player GetPlayer(int id);

        [OperationContract]
        Player AddPlayer(string fname, string lname, DateTime birth, string origin, string genre, string clubnow);

        [OperationContract]
        Player UpdatePlayer(int id, string fname, string lname, DateTime birth, string origin, string genre, string clubnow);

        [OperationContract]
        List<Player> DeletePlayer(int id);
    }
}
