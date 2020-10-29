using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable/*dispose*/
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
