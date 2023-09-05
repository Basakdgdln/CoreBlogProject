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

        public List<Blog> ContainBlog(string p)
        {
            using (var c = new Context())
            {
                var list = c.Blogs.ToList();
                if (string.IsNullOrEmpty(p))
                {
                    list = list.Where(x => x.BlogTitle.Contains(p) || x.Category.CategoryName.Contains(p) || x.BlogContent.Contains(p)).ToList();
                }
                return list;
            }
        }

        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Include(x => x.Writer).ToList();
            }
        }
        public List<Blog> GetListWithCategoryAndWriterById(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Include(x => x.Writer).Where(y => y.BlogID == id).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Include(x => x.Writer).Where(x => x.WriterID == id).ToList();
            }
        }

        public List<Blog> MaxRaytingBlog()
        {
            using (var c = new Context())
            {
                var maxrayting = c.BlogRaytings.Max(x => x.BlogTotalScore);
                var id = c.BlogRaytings.Where(x => x.BlogTotalScore == maxrayting).Select(x => x.BlogID).FirstOrDefault();
                var blog = c.Blogs.Where(x => x.BlogID == id).ToList();
                return blog;
            }
        }

    }
}
