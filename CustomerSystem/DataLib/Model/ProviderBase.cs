using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Model
{
   public interface ProviderBase<T> where  T : class
    {
        T Add(T t);
        T Remove(string id);
        T Update(T t);
        List<T> SelectAll();

    }
}
