using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class JdItemServiceMB : IBaseService<JdItem>
    {
        #region Fields

        private readonly IRepository<JdItem> _Repository;

        #endregion

        public JdItemServiceMB(IRepository<JdItem> repository)
        {
            _Repository = repository;
        }

        public void AddEntry(JdItem entry)
        {
            _Repository.Insert("InsertJdItem", entry);
        }

        public void AddEntrys(IList<JdItem> entrys)
        {
            _Repository.Insert("InsertJdItem", entrys);
        }

        public void DeleteEntry(JdItem entry)
        {
            _Repository.Delete("DeleteJdItem", entry);
        }

        public void DeleteEntrys(IList<JdItem> entrys)
        {
            _Repository.Delete("DeleteJdItem", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(JdItem entry)
        {
            throw new NotImplementedException();
        }

        public JdItem GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public JdItem GetEntry(JdItem entry)
        {
            JdItem resultentry = _Repository.GetByCondition("SelectJdItemByCondition", entry);
            return resultentry;
        }

        public IEnumerable<JdItem> GetEntrys(JdItem entry)
        {
            IList<JdItem> resultentrys = _Repository.GetList("SelectJdItemByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<JdItem> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JdItem> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JdItem> GetEntrys(int skip, int take, JdItem entry)
        {
            IList<JdItem> entrys = _Repository.GetList("SelectJdItemByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<JdItem> GetEntrys(JdItem entry, int page, int pageSize)
        {
            IList<JdItem> entrys = _Repository.GetList("SelectJdItemByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(JdItem entry)
        {
            _Repository.Update("UpdateJdItem", entry);
        }

        public void UpdateEntrys(IList<JdItem> entrys)
        {
            _Repository.Update("UpdateJdItem", entrys);
        }
    }
}