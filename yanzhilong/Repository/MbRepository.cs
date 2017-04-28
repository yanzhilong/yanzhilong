using IBatisNet.Common.Exceptions;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper.SessionStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Repository
{
    public class MbRepository<T> : IRepository<T>
    {
        public const int PAGESIZE = 10;//默认分页大小
        public static ISqlMapper sqlMapper = null;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected ISqlMapper GetLocalSqlMap()
        {
            if (sqlMapper == null)
            {
                DomSqlMapBuilder builder = new DomSqlMapBuilder();
                sqlMapper = builder.Configure();
            }

            try
            {
                var isStart = sqlMapper.IsSessionStarted;
            }
            catch (Exception)
            {
                ISessionStore ss = new HybridWebThreadSessionStore(sqlMapper.Id);
                sqlMapper.SessionStore = ss;
            }

            return sqlMapper;
        }

        
        public void Delete(string statementName, IEnumerable<T> entities)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                sqlMap.BeginTransaction();
                foreach (var item in entities)
                {
                    sqlMap.Delete(statementName, item);
                }
                sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                sqlMap.RollBackTransaction();
                logger.Error("delete entities Fail");
                throw new IBatisNetException("Error executing query '" + statementName + "' for delete.  Cause: " + e.Message, e);
            }
        }

        public void Delete(string statementName, object parameterObjec)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                sqlMap.Delete(statementName, parameterObjec);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for delete.  Cause: " + e.Message, e);
            }
        }

        public T GetByCondition(string statementName, object parameterObjec)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.QueryForObject<T>(statementName, parameterObjec);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for object.  Cause: " + e.Message, e);
            }
        }

        public IList<T> GetList(string statementName, object parameterObjec)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObjec);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        public IList<T> GetList(string statementName, object parameterObjec, int page)
        {
            page--;
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObjec, page * PAGESIZE, PAGESIZE);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        public IList<T> GetList(string statementName, object parameterObjec, int page, int pageSize)
        {
            page--;
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList<T>(statementName, parameterObjec, page * pageSize, PAGESIZE);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        public void Insert(string statementName, IEnumerable<T> entities)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                sqlMap.BeginTransaction();
                foreach (var item in entities)
                {
                    sqlMap.Insert(statementName, item);
                }
                sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                sqlMap.RollBackTransaction();
                throw new IBatisNetException("Error executing query '" + statementName + "' for insert.  Cause: " + e.Message, e);
            }
        }

        public void Insert(string statementName, T entity)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                sqlMap.Insert(statementName, entity);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for insert.  Cause: " + e.Message, e);
            }
        }

        public void Update(string statementName, IEnumerable<T> entities)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                sqlMap.BeginTransaction();
                foreach (var item in entities)
                {
                    sqlMap.Update(statementName, item);
                }
                sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                sqlMap.RollBackTransaction();
                throw new IBatisNetException("Error executing query '" + statementName + "' for update.  Cause: " + e.Message, e);
            }
        }

        public void Update(string statementName, T entity)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                sqlMap.Update(statementName, entity);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for update.  Cause: " + e.Message, e);
            }
        }

        public K GetObject<K>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForObject<K>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for query.  Cause: " + e.Message, e);
            }
        }
    }
}