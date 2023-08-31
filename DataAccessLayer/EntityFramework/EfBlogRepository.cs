using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).ToList();
            }
        }
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x => x.WriterID == id).ToList();
            }
        }

        public List<Blog> MaxRaytingBlog()
        {
            using (var c = new Context())
            {
                var maxrayting = c.BlogRaytings.Max(x => x.BlogTotalScore);
                var id = c.BlogRaytings.Where(x => x.BlogTotalScore == maxrayting).Select(x=>x.BlogID).FirstOrDefault();
                var blog = c.Blogs.Where(x => x.BlogID == id).ToList();
                return blog;
            }
        }
    }
}
