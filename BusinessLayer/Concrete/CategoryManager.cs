using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category c)
        {
            _categoryDal.Insert(c);
        }

        public List<Category> CategoryAllist()
        {
          return  _categoryDal.GetListAll();
        }

        public void CategoryDelete(Category c)
        {
            _categoryDal.Delete(c);
        }

        public void CategoryUpdate(Category c)
        {
            _categoryDal.Update(c);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }
    }
}
