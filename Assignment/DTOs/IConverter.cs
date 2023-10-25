﻿using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public interface IConverter<D, E> where D : DTO where E : IEntity
    {
        E ConvertFromDTO(D dto);
        D ConvertToDTO(E entity);
    }
}
