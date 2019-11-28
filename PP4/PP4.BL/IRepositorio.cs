using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.BL
{
    public interface IRepositorio<T>
    {
        IEnumerable Get();
        T GetrById(int ID);
        void Insert(T item);
        void Delete(int item);
        void Update(T item);
        void save();
    }
}
