using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Areas.Admin.Contollers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllCategoryList();
            if (result.ResultStatus == Common.BaseTypes.ComplexTypes.ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
    }
}
