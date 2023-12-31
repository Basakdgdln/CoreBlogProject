﻿using EntityLayer.Concrete;
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
        List<Comment> GetCommentWithBlog();
        void CommentAdd(Comment c);
        void CommentDelete(Comment c);
        Comment Get(int id);


    }
}
