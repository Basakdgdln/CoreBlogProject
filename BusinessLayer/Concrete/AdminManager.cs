﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public List<Adminn> GetList()
        {
            return _adminDal.GetListAll();
        }

        public void TAdd(Adminn t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Adminn t)
        {
            throw new NotImplementedException();
        }

        public Adminn TGetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public void TUpdate(Adminn t)
        {
            throw new NotImplementedException();
        }

    }
}
