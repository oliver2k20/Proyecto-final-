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
    /// Carrito de Compras donde se realizan las ordenes
    /// </summary>
    public class ShoppingCartController: Controller
    {
        private IHotelRepository _hotelRepository;
        private ShoppingCart _shoppingCart;

        public ShoppingCartController(IHotelRepository hotelRepository, ShoppingCart shoppingCart)
        {
            _hotelRepository = hotelRepository;
            _shoppingCart = shoppingCart;

        }
        /// <summary>
        /// Busca los itemes de las ordenes
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
        return View(shoppingCartViewModel);
        }
        /// <summary>
        /// añade elementos al carrito
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var selectedRoom = _hotelRepository.Hotels.FirstOrDefault(p => p.Id == id);
            if(selectedRoom != null)
            {
                _shoppingCart.AddToCart(selectedRoom, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult DeleteFromShoppingCart(int id)
        {
            var selectedRoom = _hotelRepository.Hotels.FirstOrDefault(p => p.Id == id);
            if (selectedRoom != null)
            {
                _shoppingCart.RemoveFromCart(selectedRoom);
            }
            return RedirectToAction("Index");
        }
    }
}
