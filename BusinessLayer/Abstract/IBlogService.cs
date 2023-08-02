using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IBlogService
    {
        List<Blog> GetList();
        void BlogAdd(Blog b);
        void BlogDelete(Blog b);
        void BlogUpdate(Blog b);
        Blog GetById(int id);
        List<Blog> GetListWithCategory();
    }
}
