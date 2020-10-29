using Blog.DataAccess.Abstract;
using Blog.Entities.Concrete;
using Blog.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete.Repositories
{
    public class ArticleRepository : EntityRepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context):base(context)
        {

        }
    }
}
