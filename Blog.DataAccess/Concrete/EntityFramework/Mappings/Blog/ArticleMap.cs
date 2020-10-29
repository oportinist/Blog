using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Content).HasColumnType("NVARCHAR(MAX)");
            builder.HasOne<Category>(x => x.Category).WithMany(y => y.Articles).HasForeignKey(z => z.CategoryId);
            //builder.HasOne<User>(x => x.User).WithMany(y => y.Articles).HasForeignKey(z => z.UserId);
            builder.ToTable("Articles");
        }
    }
}
