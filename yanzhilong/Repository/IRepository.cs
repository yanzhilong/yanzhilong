using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Repository
{
    public interface IRepository<T>
    {

        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Insert(string statementName, T entity);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="entities"></param>
        void Insert(string statementName, IEnumerable<T> entities);

        /// <summary>
        /// 根据指定条件获得实体
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        T GetByCondition(string statementName, object parameterObject);

        /// <summary>
        /// 根据指定条件获得实体
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        T GetByCondition(string statementName, T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(string statementName, T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(string statementName, IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(string statementName, object parameterObject);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(string statementName, IEnumerable<T> entities);

        /// <summary>
        /// 获得实体列表
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        IList<T> GetList(string statementName, object parameterObject);

        /// <summary>
        /// 获得实体列表
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        IList<T> GetList(string statementName, T entity);

        /// <summary>
        /// 获得实体列表分页
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="obj"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IList<T> GetList(string statementName, object parameterObject, int page);

        /// <summary>
        /// 获得实体列表分页
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="entity"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IList<T> GetList(string statementName, T entity, int page);

        /// <summary>
        /// 获得实体列表分页
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="obj"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IList<T> GetList(string statementName, object parameterObject, int page, int pageSize);

        /// <summary>
        /// 获得实体列表分页
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="entity"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IList<T> GetList(string statementName, T entity, int page, int pageSize);

        /// <summary>
        /// 获得指定的对象
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        K GetObject<K>(string statementName, object parameterObject);
        
    }
}