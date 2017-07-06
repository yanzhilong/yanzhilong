using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class SxShoeServiceMB : IBaseService<SxShoe>
    {
        #region Fields

        IRepository<SxShoe> _Repository = new MbRepository<SxShoe>();

        #endregion


        public void AddEntry(SxShoe entry)
        {
            _Repository.Insert("InsertSxShoe", entry);
        }

        public void AddEntrys(IList< SxShoe> entrys)
        {
            _Repository.Insert("InsertSxShoe", entrys);
        }

        public void DeleteEntry(SxShoe entry)
        {
            _Repository.Delete("DeleteSxShoe", entry);
        }

        public void DeleteEntrys(IList< SxShoe> entrys)
        {
            _Repository.Delete("DeleteSxShoe", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(SxShoe entry)
        {
            throw new NotImplementedException();
        }

        public SxShoe GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public SxShoe GetEntry(SxShoe entry)
        {
            SxShoe resultentry = _Repository.GetByCondition("SelectSxShoeByCondition", entry);
            return resultentry;
        }

        public IEnumerable< SxShoe> GetEntrys(SxShoe entry)
        {
            IList< SxShoe> resultentrys = _Repository.GetList("SelectSxShoeByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< SxShoe> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxShoe> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxShoe> GetEntrys(int skip, int take, SxShoe entry)
        {
            IList< SxShoe> entrys = _Repository.GetList("SelectSxShoeByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< SxShoe> GetEntrys(SxShoe entry, int page, int pageSize)
        {
            IList< SxShoe> entrys = _Repository.GetList("SelectSxShoeByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(SxShoe entry)
        {
            _Repository.Update("UpdateSxShoe", entry);
        }

        public void UpdateEntrys(IList< SxShoe> entrys)
        {
            _Repository.Update("UpdateSxShoe", entrys);
        }
    }
}
