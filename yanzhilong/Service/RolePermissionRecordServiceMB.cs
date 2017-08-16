using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class RolePermissionRecordServiceMB : IBaseService<RolePermissionRecord>
    {
        #region Fields

        private readonly IRepository<RolePermissionRecord> _Repository;

        #endregion

        public RolePermissionRecordServiceMB(IRepository<RolePermissionRecord> repository)
        {
            this._Repository = repository;
        }

        public void AddEntry(RolePermissionRecord entry)
        {
            _Repository.Insert("InsertRolePermissionRecord", entry);
        }

        public void AddEntrys(IList<RolePermissionRecord> entrys)
        {
            _Repository.Insert("InsertRolePermissionRecord", entrys);
        }

        public void DeleteEntry(RolePermissionRecord entry)
        {
            _Repository.Delete("DeleteRolePermissionRecord", entry);
        }

        public void DeleteEntrys(IList<RolePermissionRecord> entrys)
        {
            _Repository.Delete("DeleteRolePermissionRecord", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(RolePermissionRecord entry)
        {
            throw new NotImplementedException();
        }

        public RolePermissionRecord GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public RolePermissionRecord GetEntry(RolePermissionRecord entry)
        {
            RolePermissionRecord resultentry = _Repository.GetByCondition("SelectRolePermissionRecordByCondition", entry);
            return resultentry;
        }

        public IEnumerable<RolePermissionRecord> GetEntrys(RolePermissionRecord entry)
        {
            IList<RolePermissionRecord> resultentrys = _Repository.GetList("SelectRolePermissionRecordByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<RolePermissionRecord> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RolePermissionRecord> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RolePermissionRecord> GetEntrys(int skip, int take, RolePermissionRecord entry)
        {
            IList<RolePermissionRecord> entrys = _Repository.GetList("SelectRolePermissionRecordByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<RolePermissionRecord> GetEntrys(RolePermissionRecord entry, int page, int pageSize)
        {
            IList<RolePermissionRecord> entrys = _Repository.GetList("SelectRolePermissionRecordByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(RolePermissionRecord entry)
        {
            _Repository.Update("UpdateRolePermissionRecord", entry);
        }

        public void UpdateEntrys(IList<RolePermissionRecord> entrys)
        {
            _Repository.Update("UpdateRolePermissionRecord", entrys);
        }
    }
}
