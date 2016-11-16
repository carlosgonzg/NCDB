using NCDApp.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NCDApp.api.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INCDBService" in both code and config file together.
    [ServiceContract]
    public interface INCDBService
    {
        [OperationContract]
        List<User> Search();
        [OperationContract]
        bool SearchAndSend(string email, int limit);
    }
}
