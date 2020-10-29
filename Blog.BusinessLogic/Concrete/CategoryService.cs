using AutoMapper;
using Blog.BusinessLogic.Abstract;
using Blog.Common.BaseTypes.Abstract;
using Blog.Common.BaseTypes.ComplexTypes;
using Blog.Common.BaseTypes.Concrete;
using Blog.DataAccess.Abstract;
using Blog.Entities.Concrete;
using Blog.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLogic.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region AutoMapper örneği

        //public async Task<IResult> AddOOrUpdate(CategoryDto categoryDto)
        //{  
        //    var cat = _mapper.Map<Category>(categoryDto);
        //    await _unitOfWork.Categories.AddOrUpdateAsync(cat, categoryDto.Id ?? 0);
        //    return new Result(ResultStatus.Success, $"Kategori eklendi");
        //}

        #endregion
        public async Task<IResult> AddOOrUpdate(CategoryDto categoryDto)
        {
            var cat = await _unitOfWork.Categories.AddOrUpdateAsync(new Category
            {
                Id = categoryDto.Id ?? 0,
                Name = categoryDto.Name, 
                Description = categoryDto.Description
            }, categoryDto.Id ?? 0).ContinueWith(t => _unitOfWork.SaveChangesAsync());
            //await _unitOfWork.SaveChangesAsync();
            return new Result(ResultStatus.Success, $"Kategori eklendi");
        } 

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IList<Category>>> GetAllCategoryList()
        {
            var data = await _unitOfWork.Categories.ToListAsync(null, x => x.Articles);
            if (data != null && data.Count > 0)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, data);
            }
            else
            {
                return new DataResult<IList<Category>>(ResultStatus.Error, "Yok", null);
            }
        }

        public async Task<IDataResult<Category>> GetCategory(int id)
        {
            var data = await _unitOfWork.Categories.FirtsOrDefaultAsync(x => x.Id == id, x => x.Articles);
            if (data != null)
            {
                return new DataResult<Category>(ResultStatus.Success, data);
            }
            else
            {
                return new DataResult<Category>(ResultStatus.Error, "Kategori bulunamadı" ,null);
            }
        }

        public Task<IResult> SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
