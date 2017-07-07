using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class TbPropertyCategoryService : IBaseService< TbPropertyCategory >
    {
        #region Fields

        IRepository< TbPropertyCategory> _Repository = new MbRepository< TbPropertyCategory>();

        #endregion

        public void AddEntry(TbPropertyCategory entry)
        {
            _Repository.Insert("InsertTbPropertyCategory", entry);
        }

        public void AddEntrys(IList< TbPropertyCategory> entrys)
        {
            _Repository.Insert("InsertTbPropertyCategory", entrys);
        }

        public void DeleteEntry(TbPropertyCategory entry)
        {
            _Repository.Delete("DeleteTbPropertyCategory", entry);
        }

        public void DeleteEntrys(IList< TbPropertyCategory> entrys)
        {
            _Repository.Delete("DeleteTbPropertyCategory", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(TbPropertyCategory entry)
        {
            throw new NotImplementedException();
        }

        public TbPropertyCategory GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public TbPropertyCategory GetEntry(TbPropertyCategory entry)
        {
            TbPropertyCategory resultentry = _Repository.GetByCondition("SelectTbPropertyCategoryByCondition", entry);
            return resultentry;
        }

        public IEnumerable< TbPropertyCategory> GetEntrys(TbPropertyCategory entry)
        {
            IList< TbPropertyCategory> resultentrys = _Repository.GetList("SelectTbPropertyCategoryByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< TbPropertyCategory> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< TbPropertyCategory> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< TbPropertyCategory> GetEntrys(int skip, int take, TbPropertyCategory entry)
        {
            IList< TbPropertyCategory> entrys = _Repository.GetList("SelectTbPropertyCategoryByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< TbPropertyCategory> GetEntrys(TbPropertyCategory entry, int page, int pageSize)
        {
            IList< TbPropertyCategory> entrys = _Repository.GetList("SelectTbPropertyCategoryByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(TbPropertyCategory entry)
        {
            _Repository.Update("UpdateTbPropertyCategory", entry);
        }

        public void UpdateEntrys(IList< TbPropertyCategory> entrys)
        {
            _Repository.Update("UpdateTbPropertyCategory", entrys);
        }
    }
}
