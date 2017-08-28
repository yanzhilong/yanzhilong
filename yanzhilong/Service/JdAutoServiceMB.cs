using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class JdAutoServiceMB : IBaseService<JdAuto>
    {
        #region Fields

        IRepository<JdAuto> _Repository = new MbRepository<JdAuto>();

        #endregion

        public void AddEntry(JdAuto entry)
        {
            _Repository.Insert("InsertJdAuto", entry);
        }

        public void AddEntrys(IList<JdAuto> entrys)
        {
            _Repository.Insert("InsertJdAuto", entrys);
        }

        public void DeleteEntry(JdAuto entry)
        {
            _Repository.Delete("DeleteJdAuto", entry);
        }

        public void DeleteEntrys(IList<JdAuto> entrys)
        {
            _Repository.Delete("DeleteJdAuto", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(JdAuto entry)
        {
            throw new NotImplementedException();
        }

        public JdAuto GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public JdAuto GetEntry(JdAuto entry)
        {
            JdAuto resultentry = _Repository.GetByCondition("SelectJdAutoByCondition", entry);
            return resultentry;
        }

        public IEnumerable<JdAuto> GetEntrys(JdAuto entry)
        {
            IList<JdAuto> resultentrys = _Repository.GetList("SelectJdAutoByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<JdAuto> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JdAuto> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JdAuto> GetEntrys(int skip, int take, JdAuto entry)
        {
            IList<JdAuto> entrys = _Repository.GetList("SelectJdAutoByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<JdAuto> GetEntrys(JdAuto entry, int page, int pageSize)
        {
            IList<JdAuto> entrys = _Repository.GetList("SelectJdAutoByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(JdAuto entry)
        {
            _Repository.Update("UpdateJdAuto", entry);
        }

        public void UpdateEntrys(IList<JdAuto> entrys)
        {
            _Repository.Update("UpdateJdAuto", entrys);
        }
    }
}
