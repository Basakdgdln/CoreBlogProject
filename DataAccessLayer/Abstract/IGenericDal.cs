﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetListAll();
        List<T> GetListAll(Expression<Func<T, bool>> filter);
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
    }
}