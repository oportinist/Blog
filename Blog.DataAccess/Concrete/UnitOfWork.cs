using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Blog.DataAccess.Concrete.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _ctx;
        private ArticleRepository articleRepository;
        private CategoryRepository categoryRepository;
        private CommentRepository commentRepository; 
        public UnitOfWork(BlogContext ctx)
        {
            _ctx = ctx;
        }
        public IArticleRepository Articles => articleRepository ?? new ArticleRepository(_ctx);

        public ICategoryRepository Categories => categoryRepository ?? new CategoryRepository(_ctx);

        public ICommentRepository Comments => commentRepository ?? new CommentRepository(_ctx); 

        public async ValueTask DisposeAsync()
        {
            await _ctx.DisposeAsync();
        }

        public int SaveChanges()
        {
            ProcessEntityControl();
            if (!_ctx.ChangeTracker.Entries().Any(x => x.State == EntityState.Modified || x.State == EntityState.Deleted || x.State == EntityState.Added))
                return 1;
            return _ctx.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            ProcessEntityControl();
            if (!_ctx.ChangeTracker.Entries().Any(p => p.State == EntityState.Modified || p.State == EntityState.Deleted || p.State == EntityState.Added))
                return 1;
            return await _ctx.SaveChangesAsync();
        }
        private void ProcessEntityControl()
        {
            var auditEntities = _ctx.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).Select(x => new { x.Entity, x.State });
            if (auditEntities != null)
            {
                foreach (var obj in auditEntities)
                {
                    var auditEntity = obj.Entity;
                    var properties = auditEntities.GetType()
                                                  .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                                                  .Where(x => x.CanWrite).ToDictionary(x => x.Name, x => x);
                    if (obj.State == EntityState.Added || obj.State == EntityState.Detached)
                    {
                        if (properties.ContainsKey("CreateDate"))
                            properties["CreateDate"].SetValue(auditEntity, DateTime.Now);
                        if (properties.ContainsKey("CreatedByUserId"))
                            properties["CreatedByUserId"].SetValue(auditEntity, 0);
                    }
                    if (properties.ContainsKey("UpdatedDate"))
                        properties["UpdateDate"].SetValue(auditEntity, DateTime.Now);
                    if (properties.ContainsKey("UpdatedByUserId"))
                        properties["UpdatedByUserId"].SetValue(auditEntity, 0);
                }
            }
        }
    }
}
