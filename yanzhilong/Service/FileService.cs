using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class UploadFileService : IBaseService<UploadFile>
    {
        IRepository<UploadFile> _Repository = new MbRepository<UploadFile>();
        
        
        public void AddEntry(UploadFile entry)
        {
            _Repository.Insert("InsertUploadFile", entry);
        }

        public void AddEntrys(IList<UploadFile> entrys)
        {
            _Repository.Insert("InsertUploadFile", entrys);
        }

        public void DeleteEntry(UploadFile entry)
        {
            _Repository.Delete("DeleteUploadFile", entry);
        }

        public void DeleteEntrys(IList<UploadFile> entrys)
        {
            _Repository.Delete("DeleteUploadFile", entrys);
        }

        public void UpdateEntry(UploadFile entry)
        {
            _Repository.Update("UpdateUploadFile", entry);
        }

        public void UpdateEntrys(IList<UploadFile> entrys)
        {
            _Repository.Update("UpdateUploadFile", entrys);
        }

        public IEnumerable<UploadFile> GetEntrys(UploadFile entry)
        {
            IList<UploadFile> uploadFiles = _Repository.GetList("SelectUploadFileByCondition", entry);
            return uploadFiles;
        }

        public IEnumerable<UploadFile> GetEntrys(UploadFile entry, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UploadFile> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UploadFile> GetEntrys(int skip, int take, UploadFile entry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UploadFile> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public UploadFile GetEntry(UploadFile entry)
        {
            UploadFile uploadFile = _Repository.GetByCondition("SelectUploadFileByCondition", entry);
            return uploadFile;
        }

        public UploadFile GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(UploadFile entry)
        {
            throw new NotImplementedException();
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }
    }
}