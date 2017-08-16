using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class RoleServiceMB : IBaseService<Role>
    {
        #region Fields

        private readonly IRepository<Role> _Repository;

        #endregion

        public RoleServiceMB(IRepository<Role> repository)
        {
            this._Repository = repository;
        }

        public void AddEntry(Role entry)
        {
            _Repository.Insert("InsertRole", entry);
        }

        public void AddEntrys(IList<Role> entrys)
        {
            _Repository.Insert("InsertRole", entrys);
        }

        public void DeleteEntry(Role entry)
        {
            _Repository.Delete("DeleteRole", entry);
        }

        public void DeleteEntrys(IList<Role> entrys)
        {
            _Repository.Delete("DeleteRole", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Role entry)
        {
            throw new NotImplementedException();
        }

        public Role GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public Role GetEntry(Role entry)
        {
            Role resultentry = _Repository.GetByCondition("SelectRoleByCondition", entry);
            return resultentry;
        }

        public IEnumerable<Role> GetEntrys(Role entry)
        {
            IList<Role> resultentrys = _Repository.GetList("SelectRoleByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<Role> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetEntrys(int skip, int take, Role entry)
        {
            IList<Role> entrys = _Repository.GetList("SelectRoleByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<Role> GetEntrys(Role entry, int page, int pageSize)
        {
            IList<Role> entrys = _Repository.GetList("SelectRoleByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(Role entry)
        {
            _Repository.Update("UpdateRole", entry);
        }

        public void UpdateEntrys(IList<Role> entrys)
        {
            _Repository.Update("UpdateRole", entrys);
        }
    }
}
