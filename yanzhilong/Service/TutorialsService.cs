using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Models;

namespace yanzhilong.Service
{
    public class TutorialsCRUD
    {
        private SqlMapper sqlMapper = null;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TutorialsCRUD()
        {
            ISqlMapper mapper = Mapper.Instance();
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            sqlMapper = builder.Configure() as SqlMapper;
        }
        
         
        public bool Create(Tutorials tutorials)
        {
            string connectionString = sqlMapper.DataSource.ConnectionString;
            Console.WriteLine(connectionString);
            try
            {
                sqlMapper.Insert("InsertTutorials", tutorials);
                return true;
            }
            catch (Exception e) {
                logger.Error("add Tutorials Fail");
                Console.WriteLine(  e.Message.ToString());
            }
            return false;
        }
         
        public Tutorials GetTutorialsById(string tutorialsID)
        {
            Tutorials tutorials = sqlMapper.QueryForObject<Tutorials>("SelectTutorialsById", tutorialsID);
            if(tutorials != null && tutorials.user.UserID != null)
            {
                tutorials.user = sqlMapper.QueryForObject<User>("SelectUserById", tutorials.user.UserID);
            }
            return tutorials;
        }


        public IList<Tutorials> GetTutorialses()
        {
            IList<Tutorials> tutorialses = sqlMapper.QueryForList<Tutorials>("SelectAllTutorialsContainUser", null);
            return tutorialses;
        }

        public IList<Tutorials> GetTutorialses(int pageCount)
        {
            Page page = PageHelper.makePage(pageCount);
            IList<Tutorials> tutorialses = sqlMapper.QueryForList<Tutorials>("SelectAllTutorialsContainUser", null, page.PageSkip, page.PageSize);
            return tutorialses;
        }

        public PagingViewModel GetPagingViewModel(int currentPage, int pageSize)
        {
            PagingViewModel pvm = new PagingViewModel();
            pvm.CurrentPage = currentPage;
            int count = sqlMapper.QueryForObject<int>("SelectTutorialsCount", null);
            int pagecount = count / pageSize;
            if (count % pageSize == 0 && pagecount > 0)
            {
                pagecount--;
            }
            pvm.PageCount = pagecount;
            return pvm;
        }

        public IList<Tutorials> GetStarTutorialses()
        {
            IList<Tutorials> tutorialses = sqlMapper.QueryForList<Tutorials>("SelectStarTutorials", ResourceType.TUTORIALS);
            return tutorialses;
        }

        public IList<Tutorials> GetTutorialses(int index, int size)
        {
            IList<Tutorials> tutorialsList = sqlMapper.QueryForList<Tutorials>("SelectAllTutorials", null, index, size);
            return tutorialsList;
        }

        
        public bool Update(Tutorials tutorials)
        {
            int result = sqlMapper.Update("UpdateTutorials", tutorials);
            return result > 0;
        }
        

        public bool Delete(string tutorialsID)
        {
            int result = sqlMapper.Delete("DeleteTutorials", tutorialsID);
            return result > 0;
        }
    }
}