using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _BlogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _BlogDal = blogDal;
        }

        public Blog TGetById(int id)
        {
            return _BlogDal.GetById(id);
        }

        public List<Blog> GetList()
        {
            return _BlogDal.GetListAll();
        }

        public List<Blog> GetListWithCategory()
        {
            return _BlogDal.GetListWithCategory();
        }
        public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
            return _BlogDal.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _BlogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _BlogDal.GetListAll().OrderByDescending(x=>x.BlogCreateDate).Take(3).ToList();
        }

        public List<Blog> GetListWithWriter(int id)
        {
            return _BlogDal.GetListAll(x=>x.WriterID==id);
        }

        public void TAdd(Blog t)
        {
            _BlogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _BlogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _BlogDal.Update(t);
        }
    }
}
