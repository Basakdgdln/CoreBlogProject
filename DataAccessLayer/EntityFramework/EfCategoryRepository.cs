using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        Context c = new Context();

        public void CategoryStatusToFalse(int id)
        {
            var p = c.Categories.Find(id);
            p.CategoryStatus = false;
            c.SaveChanges();
        }

        public void CategoryStatusToTrue(int id)
        {
            var p = c.Categories.Find(id);
            p.CategoryStatus = true;
            c.SaveChanges();
        }
    }
}
