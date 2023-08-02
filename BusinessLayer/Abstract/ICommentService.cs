using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList(int id);
        void CommentAdd(Comment c);
        //void CommentDelete(Comment c);
        //void CommentUpdate(Comment c);
        //Comment GetById(int id);
    }
}
