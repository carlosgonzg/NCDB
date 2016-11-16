using NCDApp.bll;
using NCDApp.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NCDApp.api.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NCDBService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NCDBService.svc or NCDBService.svc.cs at the Solution Explorer and start debugging.
    public class NCDBService : INCDBService
    {
        public List<User> Search()
        {
            var userHandler = new UserHandler();
            return userHandler.Retrieve();
        }
        public bool SearchAndSend(string email, int limit)
        {
            return false;
        }
    }
}
