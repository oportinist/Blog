using Blog.Common.EntityEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreateDate { get; set; } = DateTime.Now;
        public virtual DateTime UpdateDate { get; set; } = DateTime.Now;
        public virtual int Status { get; set; } = (int)EntityStatus.Active;
        public virtual int CreatedByUserId { get; set; }
        public virtual int UpdatedByUserId { get; set; }
        public virtual string Note { get; set; }
    }
}
