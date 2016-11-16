using NCDApp.bll.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCDApp.api.Providers
{
    public class ReturnData
    {
        private DataList.CodeStatus _status;
        private string _message;
        private object _data;

        //constructor
        public ReturnData()
        {
            _status = DataList.CodeStatus.Ok;
            _message = "";
            _data = null;
        }
        public ReturnData(DataList.CodeStatus status = 0, string message = "", object data = null)
        {
            _status = status;
            _message = message;
            _data = data;
        }
        //Accesors
        public DataList.CodeStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}