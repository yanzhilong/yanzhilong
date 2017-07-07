using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class TbPropertyService : IBaseService< TbProperty >
    {
        #region Fields

        IRepository< TbProperty> _Repository = new MbRepository< TbProperty>();

        #endregion

        public void AddEntry(TbProperty entry)
        {
            _Repository.Insert("InsertTbProperty", entry);
        }

        public void AddEntrys(IList< TbProperty> entrys)
        {
            _Repository.Insert("InsertTbProperty", entrys);
        }

        public void DeleteEntry(TbProperty entry)
        {
            _Repository.Delete("DeleteTbProperty", entry);
        }

        public void DeleteEntrys(IList< TbProperty> entrys)
        {
            _Repository.Delete("DeleteTbProperty", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(TbProperty entry)
        {
            throw new NotImplementedException();
        }

        public TbProperty GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public TbProperty GetEntry(TbProperty entry)
        {
            TbProperty resultentry = _Repository.GetByCondition("SelectTbPropertyByCondition", entry);
            return resultentry;
        }

        public IEnumerable< TbProperty> GetEntrys(TbProperty entry)
        {
            IList< TbProperty> resultentrys = _Repository.GetList("SelectTbPropertyByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< TbProperty> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< TbProperty> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< TbProperty> GetEntrys(int skip, int take, TbProperty entry)
        {
            IList< TbProperty> entrys = _Repository.GetList("SelectTbPropertyByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< TbProperty> GetEntrys(TbProperty entry, int page, int pageSize)
        {
            IList< TbProperty> entrys = _Repository.GetList("SelectTbPropertyByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(TbProperty entry)
        {
            _Repository.Update("UpdateTbProperty", entry);
        }

        public void UpdateEntrys(IList< TbProperty> entrys)
        {
            _Repository.Update("UpdateTbProperty", entrys);
        }
    }
}
