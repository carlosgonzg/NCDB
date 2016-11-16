namespace NCDApp.bll.Helpers
{
    public class DataList
    {
        public enum CodeStatus : int
        {
            Ok = 0,
            CommonError = 1,
            InvalidData = 2,
            ErrorOnCreate = 3,
            ErrorOnRetrieve = 4,
            ErrorOnUpdate = 5,
            ErrorOnDelete = 6
        }
    }
}
