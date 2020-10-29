using Blog.Entities.Concrete;
using Blog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Abstract
{
    public interface ICategoryRepository : IEntityRepositoryBase<Category>
    {
    }
}
