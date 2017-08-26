using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class JdXiuXianServiceMB : IBaseService<JdXiuXian>
    {
        #region Fields

        IRepository<JdXiuXian> _Repository = new MbRepository<JdXiuXian>();

        #endregion

        public void AddEntry(JdXiuXian entry)
        {
            _Repository.Insert("InsertJdXiuXian", entry);
        }

        public void AddEntrys(IList<JdXiuXian> entrys)
        {
            _Repository.Insert("InsertJdXiuXian", entrys);
        }

        public void DeleteEntry(JdXiuXian entry)
        {
            _Repository.Delete("DeleteJdXiuXian", entry);
        }

        public void DeleteEntrys(IList<JdXiuXian> entrys)
        {
            _Repository.Delete("DeleteJdXiuXian", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(JdXiuXian entry)
        {
            throw new NotImplementedException();
        }

        public JdXiuXian GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public JdXiuXian GetEntry(JdXiuXian entry)
        {
            JdXiuXian resultentry = _Repository.GetByCondition("SelectJdXiuXianByCondition", entry);
            return resultentry;
        }

        public IEnumerable<JdXiuXian> GetEntrys(JdXiuXian entry)
        {
            IList<JdXiuXian> resultentrys = _Repository.GetList("SelectJdXiuXianByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<JdXiuXian> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JdXiuXian> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JdXiuXian> GetEntrys(int skip, int take, JdXiuXian entry)
        {
            IList<JdXiuXian> entrys = _Repository.GetList("SelectJdXiuXianByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<JdXiuXian> GetEntrys(JdXiuXian entry, int page, int pageSize)
        {
            IList<JdXiuXian> entrys = _Repository.GetList("SelectJdXiuXianByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(JdXiuXian entry)
        {
            _Repository.Update("UpdateJdXiuXian", entry);
        }

        public void UpdateEntrys(IList<JdXiuXian> entrys)
        {
            _Repository.Update("UpdateJdXiuXian", entrys);
        }
    }
}
