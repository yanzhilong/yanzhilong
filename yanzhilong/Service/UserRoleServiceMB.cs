using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class UserRoleServiceMB : IBaseService<UserRole>
    {
        #region Fields

        private readonly IRepository<UserRole> _Repository;

        #endregion

        public UserRoleServiceMB(IRepository<UserRole> repository)
        {
            this._Repository = repository;
        }

        public void AddEntry(UserRole entry)
        {
            _Repository.Insert("InsertUserRole", entry);
        }

        public void AddEntrys(IList<UserRole> entrys)
        {
            _Repository.Insert("InsertUserRole", entrys);
        }

        public void DeleteEntry(UserRole entry)
        {
            _Repository.Delete("DeleteUserRole", entry);
        }

        public void DeleteEntrys(IList<UserRole> entrys)
        {
            _Repository.Delete("DeleteUserRole", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(UserRole entry)
        {
            throw new NotImplementedException();
        }

        public UserRole GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public UserRole GetEntry(UserRole entry)
        {
            UserRole resultentry = _Repository.GetByCondition("SelectUserRoleByCondition", entry);
            return resultentry;
        }

        public IEnumerable<UserRole> GetEntrys(UserRole entry)
        {
            IList<UserRole> resultentrys = _Repository.GetList("SelectUserRoleByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<UserRole> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetEntrys(int skip, int take, UserRole entry)
        {
            IList<UserRole> entrys = _Repository.GetList("SelectUserRoleByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<UserRole> GetEntrys(UserRole entry, int page, int pageSize)
        {
            IList<UserRole> entrys = _Repository.GetList("SelectUserRoleByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(UserRole entry)
        {
            _Repository.Update("UpdateUserRole", entry);
        }

        public void UpdateEntrys(IList<UserRole> entrys)
        {
            _Repository.Update("UpdateUserRole", entrys);
        }
    }
}
