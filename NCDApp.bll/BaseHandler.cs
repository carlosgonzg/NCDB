using NCDApp.dal;
using NCDApp.bll.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NCDApp.bll
{
    public class BaseHandler<T> where T : Base 
    {
        protected NCDBDataContext _dataContext;
        public BaseHandler()
        {
            _dataContext = new NCDBDataContext();
        }
        //CRUD Functions
        public T Create(T obj)
        {
            try
            {
                obj.CreatedDate = DateTime.Now;
                _dataContext.GetTable<T>().InsertOnSubmit(obj);
            }
            catch (ValidationException e)
            {
                _dataContext.Transaction.Rollback();
                throw new CException(DataList.CodeStatus.InvalidData, e.Message);
            }
            catch (Exception e)
            {
                _dataContext.Transaction.Rollback();
                throw new CException(DataList.CodeStatus.ErrorOnCreate, e.Message);
            }
            finally
            {
                _dataContext.SubmitChanges();
            }
            return obj;
        }
        public List<T> Retrieve()
        {
            List<T> list = new List<T>();
            try
            {
                var data = from b in _dataContext.GetTable<T>() select b;
                if (data != null)
                {
                    list = data.ToList();
                }
            }
            catch (Exception e)
            {
                throw new CException(DataList.CodeStatus.ErrorOnRetrieve, e.Message);
            }
            return list;
        }
        public T Retrieve(int id)
        {
            T obj = null;
            try
            {
                var data = from b in _dataContext.GetTable<T>() where b.Id == id select b;
                if (data != null)
                {
                    obj = data.First();
                }
            }
            catch (Exception e)
            {
                throw new CException(DataList.CodeStatus.ErrorOnRetrieve, e.Message);
            }
            return obj;
        }
        public T Update(T obj)
        {
            try
            {
                var objToUpdate = (from b in _dataContext.GetTable<T>() where b.Id == obj.Id select b).First();
                if (obj == null)
                {
                    throw new Exception("There is no object to update!");
                }
                objToUpdate = obj;
            }
            catch (Exception e)
            {
                _dataContext.Transaction.Rollback();
                throw new CException(DataList.CodeStatus.ErrorOnUpdate, e.Message);
            }
            finally
            {
                _dataContext.SubmitChanges();
            }
            return obj;
        }
        public void Delete(int Id)
        {
            try
            {
                var obj = (from b in _dataContext.GetTable<T>() where b.Id == Id select b).First();
                if (obj == null)
                {
                    throw new Exception("There is no object to delete!");
                }
                _dataContext.GetTable<T>().DeleteOnSubmit(obj);
            }
            catch (Exception e)
            {
                _dataContext.Transaction.Rollback();
                throw new CException(DataList.CodeStatus.ErrorOnDelete, e.Message);
            }
            finally
            {
                _dataContext.SubmitChanges();
            }
            return;
        }
    }
}
