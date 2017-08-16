using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class PermissionRecordServiceMB : IBaseService<PermissionRecord>
    {
        #region Fields

        private readonly IRepository<PermissionRecord> _Repository;

        #endregion

        public PermissionRecordServiceMB(IRepository<PermissionRecord> repository)
        {
            this._Repository = repository;
        }

        public void AddEntry(PermissionRecord entry)
        {
            _Repository.Insert("InsertPermissionRecord", entry);
        }

        public void AddEntrys(IList<PermissionRecord> entrys)
        {
            _Repository.Insert("InsertPermissionRecord", entrys);
        }

        public void DeleteEntry(PermissionRecord entry)
        {
            _Repository.Delete("DeletePermissionRecord", entry);
        }

        public void DeleteEntrys(IList<PermissionRecord> entrys)
        {
            _Repository.Delete("DeletePermissionRecord", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(PermissionRecord entry)
        {
            throw new NotImplementedException();
        }

        public PermissionRecord GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public PermissionRecord GetEntry(PermissionRecord entry)
        {
            PermissionRecord resultentry = _Repository.GetByCondition("SelectPermissionRecordByCondition", entry);
            return resultentry;
        }

        public IEnumerable<PermissionRecord> GetEntrys(PermissionRecord entry)
        {
            IList<PermissionRecord> resultentrys = _Repository.GetList("SelectPermissionRecordByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<PermissionRecord> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PermissionRecord> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PermissionRecord> GetEntrys(int skip, int take, PermissionRecord entry)
        {
            IList<PermissionRecord> entrys = _Repository.GetList("SelectPermissionRecordByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<PermissionRecord> GetEntrys(PermissionRecord entry, int page, int pageSize)
        {
            IList<PermissionRecord> entrys = _Repository.GetList("SelectPermissionRecordByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(PermissionRecord entry)
        {
            _Repository.Update("UpdatePermissionRecord", entry);
        }

        public void UpdateEntrys(IList<PermissionRecord> entrys)
        {
            _Repository.Update("UpdatePermissionRecord", entrys);
        }
    }
}
