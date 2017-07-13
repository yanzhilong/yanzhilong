using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class TbPropertyMappingService : IBaseService< TbPropertyMapping >
    {
        #region Fields

        IRepository< TbPropertyMapping> _Repository = new MbRepository< TbPropertyMapping>();

        #endregion

        public void AddEntry(TbPropertyMapping entry)
        {
            _Repository.Insert("InsertTbPropertyMapping", entry);
        }

        public void AddEntrys(IList< TbPropertyMapping> entrys)
        {
            _Repository.Insert("InsertTbPropertyMapping", entrys);
        }

        public void DeleteEntry(TbPropertyMapping entry)
        {
            _Repository.Delete("DeleteTbPropertyMapping", entry);
        }

        public void DeleteEntrys(IList< TbPropertyMapping> entrys)
        {
            _Repository.Delete("DeleteTbPropertyMapping", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(TbPropertyMapping entry)
        {
            throw new NotImplementedException();
        }

        public TbPropertyMapping GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public TbPropertyMapping GetEntry(TbPropertyMapping entry)
        {
            TbPropertyMapping resultentry = _Repository.GetByCondition("SelectTbPropertyMappingByCondition", entry);
            return resultentry;
        }

        public IEnumerable< TbPropertyMapping> GetEntrys(TbPropertyMapping entry)
        {
            IList< TbPropertyMapping> resultentrys = _Repository.GetList("SelectTbPropertyMappingByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< TbPropertyMapping> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< TbPropertyMapping> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< TbPropertyMapping> GetEntrys(int skip, int take, TbPropertyMapping entry)
        {
            IList< TbPropertyMapping> entrys = _Repository.GetList("SelectTbPropertyMappingByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< TbPropertyMapping> GetEntrys(TbPropertyMapping entry, int page, int pageSize)
        {
            IList< TbPropertyMapping> entrys = _Repository.GetList("SelectTbPropertyMappingByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(TbPropertyMapping entry)
        {
            _Repository.Update("UpdateTbPropertyMapping", entry);
        }

        public void UpdateEntrys(IList< TbPropertyMapping> entrys)
        {
            _Repository.Update("UpdateTbPropertyMapping", entrys);
        }
    }
}
