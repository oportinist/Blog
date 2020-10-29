using Blog.DataAccess.Abstract;
using Blog.Entities.Concrete;
using Blog.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Concrete.Repositories
{
    public class CommentRepository : EntityRepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base (context)
        {

        }
    }
}
