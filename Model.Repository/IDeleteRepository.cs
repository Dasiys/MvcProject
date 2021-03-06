﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public interface IDeleteRepository<in TEntity>
    {
        void Delete(int id);
        void Delete(TEntity entity);
    }
}
