using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class JdAutoPropertyValueMB : IBaseService<JdAutoPropertyValue>
    {
        #region Fields

        IRepository<JdAutoPropertyValue> _Repository = new MbRepository<JdAutoPropertyValue>();

        #endregion

        public void AddEntry(JdAutoPropertyValue entry)
        {
            _Repository.Insert("InsertJdAutoPropertyValue", entry);
        }

        public void AddEntrys(IList<JdAutoPropertyValue> entrys)
        {
            _Repository.Insert("InsertJdAutoPropertyValue", entrys);
        }

        public void DeleteEntry(JdAutoPropertyValue entry)
        {
            _Repository.Delete("DeleteJdAutoPropertyValue", entry);
        }

        public void DeleteEntrys(IList<JdAutoPropertyValue> entrys)
        {
            _Repository.Delete("DeleteJdAutoPropertyValue", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(JdAutoPropertyValue entry)
        {
            throw new NotImplementedException();
        }

        public JdAutoPropertyValue GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public JdAutoPropertyValue GetEntry(JdAutoPropertyValue entry)
        {
            JdAutoPropertyValue resultentry = _Repository.GetByCondition("SelectJdAutoPropertyValueByCondition", entry);
            return resultentry;
        }

        public IEnumerable<JdAutoPropertyValue> GetEntrys(JdAutoPropertyValue entry)
        {
            IList<JdAutoPropertyValue> resultentrys = _Repository.GetList("SelectJdAutoPropertyValueByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<JdAutoPropertyValue> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JdAutoPropertyValue> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JdAutoPropertyValue> GetEntrys(int skip, int take, JdAutoPropertyValue entry)
        {
            IList<JdAutoPropertyValue> entrys = _Repository.GetList("SelectJdAutoPropertyValueByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<JdAutoPropertyValue> GetEntrys(JdAutoPropertyValue entry, int page, int pageSize)
        {
            IList<JdAutoPropertyValue> entrys = _Repository.GetList("SelectJdAutoPropertyValueByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(JdAutoPropertyValue entry)
        {
            _Repository.Update("UpdateJdAutoPropertyValue", entry);
        }

        public void UpdateEntrys(IList<JdAutoPropertyValue> entrys)
        {
            _Repository.Update("UpdateJdAutoPropertyValue", entrys);
        }
    }
}
