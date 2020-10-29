using Blog.Common.BaseTypes.Abstract;
using Blog.Entities.Concrete;
using Blog.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLogic.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> GetCategory(int id);
        Task<IDataResult<IList<Category>>> GetAllCategoryList();
        Task<IResult> AddOOrUpdate(CategoryDto categoryDto);
        Task<IResult> Delete(int id);
        Task<IResult> SoftDelete(int id);
    }
}
