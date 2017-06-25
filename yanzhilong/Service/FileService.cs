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
    public class UploadFileService
    {
        IRepository<UploadFile> repository = new MbRepository<UploadFile>();
        
        public void Create(UploadFile file)
        {
            repository.Insert("InsertUploadFile", file);
        }
         
        public UploadFile SelectUploadFileByCondition(UploadFile file)
        {
            UploadFile result = repository.GetByCondition("SelectUploadFileByCondition", file);
            return result;
        }

        public IList<UploadFile> GetUploadFiles()
        {
            IList<UploadFile> files = repository.GetList("SelectUploadFileByCondition", null);
            return files;
        }
 
        public IList<UploadFile> GetArticles(int pageCount)
        {
            IList<UploadFile> files = repository.GetList("SelectUploadFileByCondition", null, pageCount);
            return files;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelectUploadFileCount", null);
            return count;            
        }

        public void Update(UploadFile file)
        {
            repository.Update("UpdateUploadFile", file);
        }

        public void Delete(string Id)
        {
            repository.Delete("DeleteFile", new Article { Id = Id});
        }
    }
}