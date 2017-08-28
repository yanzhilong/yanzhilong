using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class ItemTitleServiceMB : IBaseService<ItemTitle>
    {
        #region Fields

        IRepository<ItemTitle> _Repository = new MbRepository<ItemTitle>();

        #endregion

        public void AddEntry(ItemTitle entry)
        {
            _Repository.Insert("InsertItemTitle", entry);
        }

        public void AddEntrys(IList<ItemTitle> entrys)
        {
            _Repository.Insert("InsertItemTitle", entrys);
        }

        public void DeleteEntry(ItemTitle entry)
        {
            _Repository.Delete("DeleteItemTitle", entry);
        }

        public void DeleteEntrys(IList<ItemTitle> entrys)
        {
            _Repository.Delete("DeleteItemTitle", entrys);
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(ItemTitle entry)
        {
            throw new NotImplementedException();
        }

        public ItemTitle GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public ItemTitle GetEntry(ItemTitle entry)
        {
            ItemTitle resultentry = _Repository.GetByCondition("SelectItemTitleByCondition", entry);
            return resultentry;
        }

        public IEnumerable<ItemTitle> GetEntrys(ItemTitle entry)
        {
            IList<ItemTitle> resultentrys = _Repository.GetList("SelectItemTitleByCondition", entry);
            return resultentrys;
        }

        public IEnumerable<ItemTitle> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemTitle> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemTitle> GetEntrys(int skip, int take, ItemTitle entry)
        {
            IList<ItemTitle> entrys = _Repository.GetList("SelectItemTitleByCondition", entry, skip, take);
            return entrys;
        }

        public IEnumerable<ItemTitle> GetEntrys(ItemTitle entry, int page, int pageSize)
        {
            IList<ItemTitle> entrys = _Repository.GetList("SelectItemTitleByCondition", entry, page * pageSize, pageSize);
            return entrys;
        }

        public void UpdateEntry(ItemTitle entry)
        {
            _Repository.Update("UpdateItemTitle", entry);
        }

        public void UpdateEntrys(IList<ItemTitle> entrys)
        {
            _Repository.Update("UpdateItemTitle", entrys);
        }
    }
}
