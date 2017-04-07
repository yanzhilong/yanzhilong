using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Models
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
            IList<Tutorials> tutorialses = sqlMapper.QueryForList<Tutorials>("SelectAllTutorials", null);
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