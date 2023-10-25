using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public interface IUpdater<T>
    {
        public int Update(T itemToUpdate);
    }
}
