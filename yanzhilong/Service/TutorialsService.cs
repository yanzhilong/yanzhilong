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
    public class TutorialsService
    {
        IRepository<Tutorials> repository = new MbRepository<Tutorials>();
           
        public void Create(Tutorials tutorials)
        {
            repository.Insert("InsertTutorials", tutorials);
        }
         
        public Tutorials GetTutorialsById(string tutorialsID)
        {
            Tutorials tutorials = repository.GetByCondition("SelectTutorialsById", tutorialsID);
            if (tutorials != null && tutorials.user.UserID != null)
            {
                tutorials.user = repository.GetObject<User>("SelectUserById", tutorials.user.UserID);
            }
            return tutorials;
        }

        public IList<Tutorials> GetTutorialses()
        {
            IList<Tutorials> tutorialses = repository.GetList("SelectAllTutorialsContainUser", null);
            return tutorialses;
        }

        public IList<Tutorials> GetTutorialses(int pageCount)
        {
            IList<Tutorials> tutorialses = repository.GetList("SelectAllTutorialsContainUser", null, pageCount);
            return tutorialses;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelectTutorialsCount", null);
            return count;
        }

        public IList<Tutorials> GetStarTutorialses()
        {
            IList<Tutorials> tutorialses = repository.GetList("SelectStarTutorials", ResourceType.TUTORIALS);
            return tutorialses;
        }
        
        public void Update(Tutorials tutorials)
        {
            repository.Update("UpdateTutorials", tutorials);
        }
        
        public void Delete(string tutorialsID)
        {
            repository.Delete("DeleteTutorials", tutorialsID);
        }
    }
}