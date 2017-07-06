using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class SxPropertyServiceMB : IBaseService<SxProperty>
    {
        #region Fields

        IRepository<SxProperty> _Repository = new MbRepository<SxProperty>();

        #endregion

        public void AddEntry(SxProperty entry)
        {
            _Repository.Insert("InsertSxProperty", entry);
        }

        public void AddEntrys(IList< SxProperty> entrys)
        {
            _Repository.Insert("InsertSxProperty", entrys);
        }

        public void DeleteEntry(SxProperty entry)
        {
            _Repository.Delete("DeleteSxProperty", entry);
        }

        public void DeleteEntrys(IList< SxProperty> entrys)
        {
            _Repository.Delete("DeleteSxProperty", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(SxProperty entry)
        {
            throw new NotImplementedException();
        }

        public SxProperty GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public SxProperty GetEntry(SxProperty entry)
        {
            SxProperty resultentry = _Repository.GetByCondition("SelectSxPropertyByCondition", entry);
            return resultentry;
        }

        public IEnumerable< SxProperty> GetEntrys(SxProperty entry)
        {
            IList< SxProperty> resultentrys = _Repository.GetList("SelectSxPropertyByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< SxProperty> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxProperty> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxProperty> GetEntrys(int skip, int take, SxProperty entry)
        {
            IList< SxProperty> entrys = _Repository.GetList("SelectSxPropertyByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< SxProperty> GetEntrys(SxProperty entry, int page, int pageSize)
        {
            IList< SxProperty> entrys = _Repository.GetList("SelectSxPropertyByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(SxProperty entry)
        {
            _Repository.Update("UpdateSxProperty", entry);
        }

        public void UpdateEntrys(IList< SxProperty> entrys)
        {
            _Repository.Update("UpdateSxProperty", entrys);
        }
    }
}
