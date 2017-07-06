
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class SxColorServiceMB : IBaseService<SxColor>
    {

        #region Fields

        IRepository<SxColor> _Repository = new MbRepository<SxColor>();

        #endregion

        public void AddEntry(SxColor entry)
        {
            _Repository.Insert("InsertSxColor", entry);
        }

        public void AddEntrys(IList< SxColor> entrys)
        {
            _Repository.Insert("InsertSxColor", entrys);
        }

        public void DeleteEntry(SxColor entry)
        {
            _Repository.Delete("DeleteSxColor", entry);
        }

        public void DeleteEntrys(IList< SxColor> entrys)
        {
            _Repository.Delete("DeleteSxColor", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(SxColor entry)
        {
            throw new NotImplementedException();
        }

        public SxColor GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public SxColor GetEntry(SxColor entry)
        {
            SxColor resultentry = _Repository.GetByCondition("SelectSxColorByCondition", entry);
            return resultentry;
        }

        public IEnumerable< SxColor> GetEntrys(SxColor entry)
        {
            IList< SxColor> resultentrys = _Repository.GetList("SelectSxColorByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< SxColor> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxColor> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxColor> GetEntrys(int skip, int take, SxColor entry)
        {
            IList< SxColor> entrys = _Repository.GetList("SelectSxColorByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< SxColor> GetEntrys(SxColor entry, int page, int pageSize)
        {
            IList< SxColor> entrys = _Repository.GetList("SelectSxColorByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(SxColor entry)
        {
            _Repository.Update("UpdateSxColor", entry);
        }

        public void UpdateEntrys(IList< SxColor> entrys)
        {
            _Repository.Update("UpdateSxColor", entrys);
        }
    }
}
