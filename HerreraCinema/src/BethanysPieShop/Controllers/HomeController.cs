using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Acciones de Home
/// </summary>
namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HomeController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        /// <summary>
        /// Devuelve un viewmodel de las habitaciones disponibles
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Hotels = _hotelRepository.Hotels
            };

            return View(homeViewModel);
        }
    }
}
