using System;


namespace NCDApp.bll.Helpers
{
    public class CException : Exception
    {
        private DataList.CodeStatus _status;
        public CException() : base()
        {

        }

        public CException(DataList.CodeStatus status, string message) : base(message)
        {
            _status = status;
        }

        public DataList.CodeStatus Status
        {
            get { return _status; }
        }
    }
}
