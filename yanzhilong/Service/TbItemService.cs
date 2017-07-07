using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class TbItemService : IBaseService< TbItem >
    {
        #region Fields

        IRepository< TbItem> _Repository = new MbRepository< TbItem>();

        #endregion

        public void AddEntry(TbItem entry)
        {
            _Repository.Insert("InsertTbItem", entry);
        }

        public void AddEntrys(IList< TbItem> entrys)
        {
            _Repository.Insert("InsertTbItem", entrys);
        }

        public void DeleteEntry(TbItem entry)
        {
            _Repository.Delete("DeleteTbItem", entry);
        }

        public void DeleteEntrys(IList< TbItem> entrys)
        {
            _Repository.Delete("DeleteTbItem", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(TbItem entry)
        {
            throw new NotImplementedException();
        }

        public TbItem GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public TbItem GetEntry(TbItem entry)
        {
            TbItem resultentry = _Repository.GetByCondition("SelectTbItemByCondition", entry);
            return resultentry;
        }

        public IEnumerable< TbItem> GetEntrys(TbItem entry)
        {
            IList< TbItem> resultentrys = _Repository.GetList("SelectTbItemByCondition", entry);
            return resultentrys;
        }

        public IEnumerable< TbItem> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< TbItem> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable< TbItem> GetEntrys(int skip, int take, TbItem entry)
        {
            IList< TbItem> entrys = _Repository.GetList("SelectTbItemByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable< TbItem> GetEntrys(TbItem entry, int page, int pageSize)
        {
            IList< TbItem> entrys = _Repository.GetList("SelectTbItemByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(TbItem entry)
        {
            _Repository.Update("UpdateTbItem", entry);
        }

        public void UpdateEntrys(IList< TbItem> entrys)
        {
            _Repository.Update("UpdateTbItem", entrys);
        }
    }
}
