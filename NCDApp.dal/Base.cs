using System;
using System.Runtime.Serialization;

namespace NCDApp.dal
{
    [DataContract]
    abstract public class Base
    {
        public Base() : base()
        {

        }
        [DataMember]
        abstract public int Id
        {
            get;
        }
        [DataMember]
        abstract public DateTime CreatedDate
        {
            get;
            set;
        }
    }
}
