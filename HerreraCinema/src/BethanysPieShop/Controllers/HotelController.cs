using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    /// <summary>
    /// El controlador para los Hoteles
    /// </summary>
    public class HotelController: Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHotelRepository _hotelRepository;
        //Inyeccion de dependencias
        public HotelController(IHotelRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _hotelRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        /// <summary>
        /// Muestra una lista de los hoteles basado en la categoria
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public ViewResult List(string category)
        {
            IEnumerable<Hotel> hotels;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                hotels = _hotelRepository.Hotels.OrderBy(p => p.Id);
                currentCategory = "Todos";
            }
            else
            {
                hotels = _hotelRepository.Hotels.Where(p => p.Category.CategoryName == category)
                   .OrderBy(p => p.Id);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new HotelsListViewModel
            {
                Hotels = hotels,
                CurrentCategory = currentCategory
            });
        }
        /// <summary>
        /// Muestra los detalles del hotel basado en un id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);
            if (hotel == null)
                return NotFound();

            return View(hotel);
        }
    }
}
