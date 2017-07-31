using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Components
{
    /// <summary>
    /// Este es un componente para ver los Menus
    /// </summary>
    public class CategoryMenu : ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryRepository"></param>
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public object CategoryName { get; private set; }
        /// <summary>
        /// Invoca el categorias
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(c => CategoryName);
            return View(categories);
        }
    }
}
