using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class SxSsizeServiceMB : IBaseService<SxSsize>
    {
        #region Fields

        IRepository<SxSsize> _Repository = new MbRepository<SxSsize>();

        #endregion


        public void AddEntry(SxSsize entry)
        {
            _Repository.Insert("InsertSxSsize", entry);
        }

        public void AddEntrys(IList< SxSsize> entrys)
        {
            _Repository.Insert("InsertSxSsize", entrys);
        }

        public void DeleteEntry(SxSsize entry)
        {
            _Repository.Delete("DeleteSxSsize", entry);
        }

        public void DeleteEntrys(IList< SxSsize> entrys)
        {
            _Repository.Delete("DeleteSxSsize", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(SxSsize entry)
        {
            throw new NotImplementedException();
        }

        public SxSsize GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public SxSsize GetEntry(SxSsize entry)
        {
            SxSsize resultentry = _Repository.GetByCondition("SelectSxSsizeByCondition", entry);
            return resultentry;
        }

        public IEnumerable< SxSsize> GetEntrys(SxSsize entry)
        {
            IList< SxSsize> resultentrys = _Repository.GetList("SelectSxSsizeByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< SxSsize> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxSsize> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< SxSsize> GetEntrys(int skip, int take, SxSsize entry)
        {
            IList< SxSsize> entrys = _Repository.GetList("SelectSxSsizeByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< SxSsize> GetEntrys(SxSsize entry, int page, int pageSize)
        {
            IList< SxSsize> entrys = _Repository.GetList("SelectSxSsizeByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(SxSsize entry)
        {
            _Repository.Update("UpdateSxSsize", entry);
        }

        public void UpdateEntrys(IList< SxSsize> entrys)
        {
            _Repository.Update("UpdateSxSsize", entrys);
        }
    }
}
