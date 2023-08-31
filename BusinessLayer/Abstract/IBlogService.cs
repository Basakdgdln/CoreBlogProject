using EntityLayer.Concrete;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> MaxRaytingBlog();
        List<Blog> GetListWithWriter(int id);

    }
}
