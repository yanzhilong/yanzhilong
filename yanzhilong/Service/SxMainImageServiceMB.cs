using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class SxMainImageServiceMB : IBaseService<SxMainImage>
    {
        #region Fields

        IRepository<SxMainImage> _Repository = new MbRepository<SxMainImage>();

        #endregion

        public void AddEntry(SxMainImage entry)
        {
            _Repository.Insert("InsertSxMainImage", entry);
        }

        public void AddEntrys(IList< SxMainImage> entrys)
        {
            _Repository.Insert("InsertSxMainImage", entrys);
        }

        public void DeleteEntry(SxMainImage entry)
        {
            _Repository.Delete("DeleteSxMainImage", entry);
        }

        public void DeleteEntrys(IList< SxMainImage> entrys)
        {
            _Repository.Delete("DeleteSxMainImage", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(SxMainImage entry)
        {
            throw new NotImplementedException();
        }

        public SxMainImage GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public SxMainImage GetEntry(SxMainImage entry)
        {
            SxMainImage resultentry = _Repository.GetByCondition("SelectSxMainImageByCondition", entry);
            return resultentry;
        }

        public IEnumerable< SxMainImage> GetEntrys(SxMainImage entry)
        {
            IList< SxMainImage> resultentrys = _Repository.GetList("SelectSxMainImageByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< SxMainImage> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxMainImage> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxMainImage> GetEntrys(int skip, int take, SxMainImage entry)
        {
            IList< SxMainImage> entrys = _Repository.GetList("SelectSxMainImageByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< SxMainImage> GetEntrys(SxMainImage entry, int page, int pageSize)
        {
            IList< SxMainImage> entrys = _Repository.GetList("SelectSxMainImageByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(SxMainImage entry)
        {
            _Repository.Update("UpdateSxMainImage", entry);
        }

        public void UpdateEntrys(IList< SxMainImage> entrys)
        {
            _Repository.Update("UpdateSxMainImage", entrys);
        }
    }
}
