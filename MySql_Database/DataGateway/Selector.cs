using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public interface ISelector<T>
    {
        public T Select();
    }
}
