using BusinessLayer.Abstract;
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
        EfCategoryRepository efCategoryRepository;
        public CategoryManager()
        {
            efCategoryRepository = new EfCategoryRepository();
        }

        public void CategoryAdd(Category c)
        {
            efCategoryRepository.Insert(c);
        }

        public List<Category> CategoryAllist()
        {
          return  efCategoryRepository.GetListAll();
        }

        public void CategoryDelete(Category c)
        {
            efCategoryRepository.Delete(c);
        }

        public void CategoryUpdate(Category c)
        {
            efCategoryRepository.Update(c);
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetById(id);
        }
    }
}
