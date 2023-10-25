using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public interface IInserter<T>
    {
        public int Insert(T itemToInsert);
    }
}
