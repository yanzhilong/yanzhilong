using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Service
{
    public interface IBaseService<T>
    {
        void AddEntity(T entity);

        void AddEntrys(IList<T> entrys);

        void DeleteEntry(T entry);

        void DeleteEntrys(IList<T> entrys);

        void UpdateEntry(T entry);

        void UpdateEntrys(IList<T> entrys);

        IEnumerable<T> GetEntrys(T entry);

        IEnumerable<T> GetEntrys(T entry, int page, int pageSize);

        IEnumerable<T> GetEntrys(Object parameterObject, int page, int pageSize);

        IEnumerable<T> GetEntrys(int skip, int take, T entry);

        IEnumerable<T> GetEntrys(int skip, int take, Object parameterObject);

        T GetEntry(T entry);

        T GetEntry(Object parameterObject);

        int GetCount(T entry);

        int GetCount(Object parameterObject);
    }
}
