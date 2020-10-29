using Blog.Entities.Concrete;
using Blog.Shared.Data.Abstract;
using Blog.Shared.Data.Concrete.EntityFramework;

namespace Blog.DataAccess.Abstract
{
    public interface IArticleRepository : IEntityRepositoryBase<Article>
    { 
        
    }
}
