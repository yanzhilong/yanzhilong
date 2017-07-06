
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class SxImageServiceMB : IBaseService<SxImage>
    {
        #region Fields

        IRepository<SxImage> _Repository = new MbRepository<SxImage>();

        #endregion


        public void AddEntry(SxImage entry)
        {
            _Repository.Insert("InsertSxImage", entry);
        }

        public void AddEntrys(IList< SxImage> entrys)
        {
            _Repository.Insert("InsertSxImage", entrys);
        }

        public void DeleteEntry(SxImage entry)
        {
            _Repository.Delete("DeleteSxImage", entry);
        }

        public void DeleteEntrys(IList< SxImage> entrys)
        {
            _Repository.Delete("DeleteSxImage", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(SxImage entry)
        {
            throw new NotImplementedException();
        }

        public SxImage GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public SxImage GetEntry(SxImage entry)
        {
            SxImage resultentry = _Repository.GetByCondition("SelectSxImageByCondition", entry);
            return resultentry;
        }

        public IEnumerable< SxImage> GetEntrys(SxImage entry)
        {
            IList< SxImage> resultentrys = _Repository.GetList("SelectSxImageByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< SxImage> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxImage> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxImage> GetEntrys(int skip, int take, SxImage entry)
        {
            IList< SxImage> entrys = _Repository.GetList("SelectSxImageByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< SxImage> GetEntrys(SxImage entry, int page, int pageSize)
        {
            IList< SxImage> entrys = _Repository.GetList("SelectSxImageByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(SxImage entry)
        {
            _Repository.Update("UpdateSxImage", entry);
        }

        public void UpdateEntrys(IList< SxImage> entrys)
        {
            _Repository.Update("UpdateSxImage", entrys);
        }
    }
}
