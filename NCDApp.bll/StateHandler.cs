using System;
using System.Linq;
using NCDApp.dal;
using NCDApp.bll.Helpers;
using System.Collections.Generic;

namespace NCDApp.bll
{
    public class StateHandler : BaseHandler<State>
    {
        public StateHandler() : base()
        {
        }
        public List<State> GetByCountry(int countryId)
        {
            List<State> list = new List<State>();
            try
            {
                list = (from b in _dataContext.States where b.CountryId == countryId select b).ToList();
            }
            catch (Exception e)
            {
                throw new CException(DataList.CodeStatus.ErrorOnRetrieve, e.Message);
            }
            return list;
        }
    }
}
