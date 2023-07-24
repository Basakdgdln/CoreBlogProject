using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
    {
        List<Category> CategoryAllist();
        void CategoryAdd(Category c);
        void CategoryDelete(Category c);
        void CategoryUpdate(Category c);
        Category GetById(int id);
    }
}
